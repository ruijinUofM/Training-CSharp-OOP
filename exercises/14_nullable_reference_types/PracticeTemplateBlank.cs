// Nullable Reference Types -- UserProfile + UserHelpers, written from scratch.
//
// Required classes and behavior:
//
//   UserProfile:
//       Name (string) — must be provided at construction; cannot be null; immutable
//           after construction; compiler should enforce that it's always set.
//       Bio (string or null) — optional; immutable after construction.
//       GetDisplayName() → string — returns Name.
//       GetBio() → string — returns Bio if set, otherwise "No bio provided".
//       GetBioLength() → int — returns Bio's length, or 0 if Bio is null.
//
//   UserHelpers — static helper methods:
//       FindUser(List<UserProfile>, string name) → UserProfile or null — finds
//           the first profile matching name, or null if not found.
//       GetUpperName(UserProfile or null) → string — returns Name uppercased,
//           or "UNKNOWN" if profile is null.

namespace Kata;

// Write your implementation below.
