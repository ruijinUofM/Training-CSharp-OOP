namespace Kata;

class UserProfile
{
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string GetDisplayName() { throw new NotImplementedException(); }
    public string GetBio() { throw new NotImplementedException(); }
    public int GetBioLength() { throw new NotImplementedException(); }
}

static class UserHelpers
{
    public static UserProfile? FindUser(List<UserProfile> users, string name)
    { throw new NotImplementedException(); }

    public static string GetUpperName(UserProfile? profile)
    { throw new NotImplementedException(); }
}
