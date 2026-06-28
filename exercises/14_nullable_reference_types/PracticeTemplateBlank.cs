// Nullable Reference Types -- UserProfile + UserHelpers, written from scratch.
//
// Required API:
//
//   class UserProfile
//   {
//       public required string Name { get; init; }   // non-nullable, required
//       public string? Bio { get; init; }             // nullable, optional
//       public string GetDisplayName() => Name;
//       public string GetBio()        => Bio ?? "No bio provided";
//       public int GetBioLength()     => Bio?.Length ?? 0;
//   }
//
//   static class UserHelpers
//   {
//       public static UserProfile? FindUser(List<UserProfile> users, string name)
//           // FirstOrDefault by name, or null
//
//       public static string GetUpperName(UserProfile? profile)
//           // profile?.Name?.ToUpper() ?? "UNKNOWN"
//   }

namespace Kata;

// Write your implementation below.
