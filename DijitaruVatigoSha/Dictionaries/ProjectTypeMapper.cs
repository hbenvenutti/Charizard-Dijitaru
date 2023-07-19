using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dictionaries;

public static class ProjectTypeMapper
{
    private static IDictionary<string, ProjectType> map = 
        new Dictionary<string, ProjectType>
    {
        {"SquadService", ProjectType.SquadService},
        {"Outsourcing", ProjectType.Outsourcing}
    };

    public static string ProjectTypeToString(this ProjectType projectType)
    {
        return nameof(projectType);
        // return map.First(x => x.Value == role).Key;
    }

    public static ProjectType ToProjectType(this string projectType)
    {
        return map[projectType];
        // return map.First(x => x.Key == role).Value;
    }
}
