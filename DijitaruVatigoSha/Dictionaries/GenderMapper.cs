using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dictionaries;

public static class GenderMapper
{
    private static IDictionary<string, Gender> map = 
        new Dictionary<string, Gender>
    {
        {"Male", Gender.Male},
        {"Female", Gender.Female},
    };

    public static string GenderToString(this Gender gender)
    {
        // return nameof(gender);
        return map.First(key => key.Value == gender).Key;
    }

    public static Gender ToGender(this string gender)
    {
        // return map[gender];
        return map.First(value => value.Key == gender).Value;
    }
}
