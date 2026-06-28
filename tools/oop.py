#!/usr/bin/env python3
"""Helper CLI for the Training-CSharp-OOP exercise repo.

Usage:
    python tools/oop.py list
    python tools/oop.py reset <NN|name> [--blank|--full]
    python tools/oop.py reset --all [--blank|--full]
    python tools/oop.py test [<NN|name>]
    python tools/oop.py solution <NN|name> [--show]
    python tools/oop.py new <NN_name>

Exercises can be identified by their two-digit number ("07"), their full
directory name ("07_generic_constraints"), or a unique substring ("generic").
"""

import argparse
import filecmp
import shutil
import subprocess
import sys
from pathlib import Path

REPO_ROOT = Path(__file__).resolve().parent.parent
EXERCISES_DIR = REPO_ROOT / "exercises"
TEMPLATE_DIR = EXERCISES_DIR / "_template"


def list_exercises() -> list[Path]:
    return sorted(
        p for p in EXERCISES_DIR.iterdir() if p.is_dir() and not p.name.startswith("_")
    )


def resolve_exercise(identifier: str) -> Path:
    exercises = list_exercises()

    candidates = [e for e in exercises if e.name == identifier]

    if not candidates:
        normalized = identifier.zfill(2)
        candidates = [
            e for e in exercises if e.name == normalized or e.name.startswith(normalized + "_")
        ]

    if not candidates:
        needle = identifier.lower()
        candidates = [e for e in exercises if needle in e.name.lower()]

    if not candidates:
        raise SystemExit(f"No exercise matches '{identifier}'")
    if len(candidates) > 1:
        names = ", ".join(e.name for e in candidates)
        raise SystemExit(f"'{identifier}' matches multiple exercises: {names}")
    return candidates[0]


def find_csproj(exercise: Path) -> Path | None:
    projs = list(exercise.glob("*.csproj"))
    return projs[0] if projs else None


def run_dotnet_test(exercise: Path) -> int:
    proj = find_csproj(exercise)
    if proj is None:
        print(f"  [skip] {exercise.name}: no .csproj found")
        return 1
    result = subprocess.run(
        ["dotnet", "test", str(proj), "-q", "--nologo"],
        cwd=exercise,
        capture_output=True,
    )
    return result.returncode


def cmd_list(_args: argparse.Namespace) -> None:
    for exercise in list_exercises():
        practice = exercise / "Practice.cs"
        full_template = exercise / "PracticeTemplateFull.cs"
        blank_template = exercise / "PracticeTemplateBlank.cs"

        if not practice.exists() or not full_template.exists() or not blank_template.exists():
            status = "[ ]     "
        elif filecmp.cmp(practice, full_template, shallow=False) or filecmp.cmp(
            practice, blank_template, shallow=False
        ):
            status = "[ ]     "
        else:
            rc = run_dotnet_test(exercise)
            status = "[PASS]  " if rc == 0 else "[FAIL]  "

        print(f"{status}{exercise.name}")


def cmd_reset(args: argparse.Namespace) -> None:
    if args.all:
        exercises = list_exercises()
    else:
        exercises = [resolve_exercise(args.exercise)]

    variant = "blank" if args.blank else "full"
    template_name = f"PracticeTemplate{'Blank' if args.blank else 'Full'}.cs"

    for exercise in exercises:
        template = exercise / template_name
        practice = exercise / "Practice.cs"
        if not template.exists():
            print(f"  [skip] {exercise.name}: no {template_name}")
            continue
        shutil.copyfile(template, practice)
        print(f"Reset {exercise.name} ({variant})")


def cmd_test(args: argparse.Namespace) -> None:
    if args.exercise:
        exercise = resolve_exercise(args.exercise)
        proj = find_csproj(exercise)
        if proj is None:
            raise SystemExit(f"No .csproj in {exercise.name}")
        result = subprocess.run(["dotnet", "test", str(proj), "-v", "normal", "--nologo"], cwd=exercise)
        sys.exit(result.returncode)
    else:
        failed = 0
        for exercise in list_exercises():
            proj = find_csproj(exercise)
            if proj is None:
                continue
            print(f"\n--- {exercise.name} ---")
            rc = subprocess.run(["dotnet", "test", str(proj), "-q", "--nologo"], cwd=exercise).returncode
            if rc != 0:
                failed += 1
        sys.exit(0 if failed == 0 else 1)


def cmd_solution(args: argparse.Namespace) -> None:
    exercise = resolve_exercise(args.exercise)
    solution = exercise / "Solution.cs"
    print(solution)
    if args.show:
        print()
        print(solution.read_text())


def cmd_new(args: argparse.Namespace) -> None:
    dest = EXERCISES_DIR / args.name
    if dest.exists():
        raise SystemExit(f"{dest} already exists")
    shutil.copytree(TEMPLATE_DIR, dest)
    # rename the csproj to match the new directory
    template_proj = dest / "_template.csproj"
    if template_proj.exists():
        template_proj.rename(dest / f"{args.name}.csproj")
    shutil.copyfile(dest / "PracticeTemplateFull.cs", dest / "Practice.cs")
    print(f"Created {dest}")
    print(f"Edit README.md, Solution.cs, PracticeTemplateFull.cs, and PracticeTests.cs.")


def main() -> None:
    parser = argparse.ArgumentParser(description="Training-CSharp-OOP exercise helper")
    sub = parser.add_subparsers(dest="command", required=True)

    sub.add_parser("list", help="Show every exercise and its status")

    p_reset = sub.add_parser("reset", help="Reset an exercise's Practice.cs back to its stub")
    p_reset.add_argument("exercise", nargs="?")
    p_reset.add_argument("--all", action="store_true")
    template_group = p_reset.add_mutually_exclusive_group()
    template_group.add_argument("--blank", action="store_true")
    template_group.add_argument("--full", action="store_true")

    p_test = sub.add_parser("test", help="Run dotnet test for one exercise, or all")
    p_test.add_argument("exercise", nargs="?")

    p_solution = sub.add_parser("solution", help="Show path to Solution.cs")
    p_solution.add_argument("exercise")
    p_solution.add_argument("--show", action="store_true")

    p_new = sub.add_parser("new", help="Scaffold a new exercise from _template")
    p_new.add_argument("name")

    args = parser.parse_args()

    if args.command == "reset" and not args.all and not args.exercise:
        raise SystemExit("Specify an exercise to reset, or use --all")

    {
        "list": cmd_list,
        "reset": cmd_reset,
        "test": cmd_test,
        "solution": cmd_solution,
        "new": cmd_new,
    }[args.command](args)


if __name__ == "__main__":
    main()
