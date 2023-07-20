using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dictionaries;

public static class RoleMapper
{
    private static readonly IDictionary<string, Role> map = 
        new Dictionary<string, Role>
    {
        {"Normal", Role.Normal},
        {"Approver", Role.Approver},
        {"Admin", Role.Admin}
    };

    public static string RoleToString(this Role role)
    {
        // return nameof(role);
        return map.First(x => x.Value == role).Key;
    }

    public static Role ToRole(this string role)
    {
        // return map[role];
        return map.First(x => x.Key == role).Value;
    }
}
