using LetsSpeak.Repositories.Interfaces;
using Newtonsoft.Json;

namespace LetsSpeak.Repositories;

internal class TermRepository : ITermRepository
{
    private readonly string _fileName;

    private Dictionary<string, string> _terms;

    public TermRepository()
    {
        _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "terms.json");

        Load();
    }

    void Load()
    {
        string json = File.ReadAllText(_fileName);

        _terms = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
            ?? new Dictionary<string, string>();
    }

    public List<KeyValuePair<string, string>> GetTerms(string term)
    {
        return _terms.Where(
            t => t.Key.Contains(term, StringComparison.InvariantCultureIgnoreCase)
        ).ToList();
    }

    public string GetTermMeaning(string term)
    {
        return _terms.FirstOrDefault(
            t => t.Key.Equals(term, StringComparison.CurrentCultureIgnoreCase)
        )!.Value;
    }

    public void AddTerm(string term, string meaning)
    {
        _terms.Add(term, meaning);
        Save(_terms);
    }

    private void Save(Dictionary<string, string> terms)
    {
        string json = JsonConvert.SerializeObject(terms);
        File.WriteAllText("terms.json", json);
    }
}
