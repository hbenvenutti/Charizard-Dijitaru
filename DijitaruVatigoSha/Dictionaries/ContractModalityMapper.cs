using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dictionaries;

public static class ContractModalityMapper
{
    private static IDictionary<string, ContractModality> map = 
        new Dictionary<string, ContractModality>
    {
        {"Clt", ContractModality.Clt},
        {"Pj", ContractModality.Pj},
        {"Intern", ContractModality.Intern}
    };

    public static string ModalityToString(this ContractModality modality)
    {
        return nameof(modality);
        // return map.First(x => x.Value == role).Key;
    }

    public static ContractModality ToContractModality(this string modality)
    {
        return map[modality];
        // return map.First(x => x.Key == role).Value;
    }
}
