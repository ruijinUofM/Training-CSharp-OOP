# Training-CSharp-OOP

A self-contained set of C# language-feature exercises. Each exercise focuses on one OOP or C#-specific concept: a stub to implement in `Practice.cs`, an xUnit test suite that checks the required behavior, and a reference `Solution.cs` to compare against afterward.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Python 3.10+ (for the CLI helper `tools/oop.py`)

No global `dotnet test` setup needed — each exercise is its own project.

## Curriculum

| # | Exercise | Feature | Case study |
|---|----------|---------|------------|
| 01 | [`01_inheritance`](exercises/01_inheritance) | `virtual` / `override`, `base` | `Animal` / `Dog` / `Cat` hierarchy |
| 02 | [`02_abstract_classes`](exercises/02_abstract_classes) | `abstract class`, `abstract` methods | `Shape` / `Circle` / `Rectangle` |
| 03 | [`03_interfaces`](exercises/03_interfaces) | `interface`, multiple implementation | `IDrawable` + `IResizable` → `Circle`, `Square` |
| 04 | [`04_sealed_classes`](exercises/04_sealed_classes) | `sealed class`, `sealed override` | `Logger` / `ConsoleLogger` / `FileLogger` |
| 05 | [`05_partial_classes`](exercises/05_partial_classes) | `partial class`, split across files | `CustomerOrder` with auto-generated half |
| 06 | [`06_generics`](exercises/06_generics) | `class Foo<T>`, multi-type parameters | `Stack<T>` and `Pair<T, U>` |
| 07 | [`07_generic_constraints`](exercises/07_generic_constraints) | `where T : IComparable<T>`, `class, new()`, `struct` | `Algorithms.Max<T>` and `Repository<T>` |
| 08 | [`08_extension_methods`](exercises/08_extension_methods) | `static class` with `this T` | `StringExtensions` and `IntExtensions` |
| 09 | [`09_properties`](exercises/09_properties) | Auto-props, backing fields, `private set` | `BankAccount` with Deposit/Withdraw |
| 10 | [`10_records`](exercises/10_records) | `record`, `record struct`, `with`, deconstruction | `Point` and `Color` |
| 11 | [`11_delegates_events`](exercises/11_delegates_events) | `event`, `EventHandler`, `Action<T>` | `Button.Clicked` and `Counter.CountChanged` |
| 12 | [`12_dependency_injection`](exercises/12_dependency_injection) | Constructor injection, interfaces | `NotificationService` + `FakeEmailSender` |
| 13 | [`13_enums`](exercises/13_enums) | `enum`, `[Flags]`, extension methods on enums | `OrderStatus` transitions, `Permission` flags |
| 14 | [`14_nullable_reference_types`](exercises/14_nullable_reference_types) | `string?`, `??`, `?.`, `required` | `UserProfile` with optional `Bio` |
| 15 | [`15_pattern_matching`](exercises/15_pattern_matching) | `switch` expression, positional + relational patterns | `ShapeMath.Area` and `Classify(int)` |
| 16 | [`16_async_await`](exercises/16_async_await) | `async`/`await`, `Task.WhenAll`, `CancellationToken` | `AsyncHelpers` simulating I/O |
| 17 | [`17_linq`](exercises/17_linq) | `Where`, `Select`, `GroupBy`, `Sum`, `OrderBy` | `ProductQueries` on a product catalog |
| 18 | [`18_covariance_contravariance`](exercises/18_covariance_contravariance) | `out T` (covariant), `in T` (contravariant) | `IProducer<out T>` / `IConsumer<in T>` |
| 19 | [`19_indexers_operators`](exercises/19_indexers_operators) | Indexers (`this[...]`), operator overloading | `Matrix` with `+`, `*`, `==` |
| 20 | [`20_attributes_reflection`](exercises/20_attributes_reflection) | Custom attributes, `PropertyInfo`, reflection | `[Validate]` + `FormValidator.Validate<T>` |

## Daily workflow

1. Pick an exercise from the table above.
2. Read that exercise's `README.md` for the feature, case study, and required API.
3. Open `Practice.cs` and implement the required code.
4. Run the tests until they pass:
   `python tools/oop.py test <NN>`
5. Compare against the reference:
   `python tools/oop.py solution <NN> --show`

`<NN>` accepts the two-digit number (`07`), the full directory name (`07_generic_constraints`), or any unique substring (`generic`).

## CLI reference

```bash
# Show every exercise and whether it's not started / passing / failing
python tools/oop.py list

# Reset Practice.cs to the full guided skeleton (default)
python tools/oop.py reset 07

# Reset to the blank, from-scratch template
python tools/oop.py reset 07 --blank

# Reset every exercise
python tools/oop.py reset --all
python tools/oop.py reset --all --blank

# Run the test suite for one exercise, or all
python tools/oop.py test 07
python tools/oop.py test

# Print the path to an exercise's Solution.cs, optionally with source
python tools/oop.py solution 07
python tools/oop.py solution 07 --show

# Scaffold a new exercise directory from exercises/_template
python tools/oop.py new 21_iterators
```

## Running tests directly

```bash
cd exercises/07_generic_constraints
dotnet test -v normal --nologo
```

Each exercise's `.csproj` is self-contained — no solution file needed.
