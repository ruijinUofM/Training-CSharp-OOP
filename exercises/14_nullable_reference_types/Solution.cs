namespace Kata;

class UserProfile
{
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string GetDisplayName() => Name;
    public string GetBio() => Bio ?? "No bio provided";
    public int GetBioLength() => Bio?.Length ?? 0;
}

static class UserHelpers
{
    public static UserProfile? FindUser(List<UserProfile> users, string name)
        => users.FirstOrDefault(u => u.Name == name);

    public static string GetUpperName(UserProfile? profile)
        => profile?.Name?.ToUpper() ?? "UNKNOWN";
}
