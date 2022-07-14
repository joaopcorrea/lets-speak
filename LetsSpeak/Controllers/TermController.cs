using LetsSpeak.Controllers.Interfaces;
using LetsSpeak.Repositories.Interfaces;

namespace LetsSpeak.Controllers;

internal class TermController : ITermController
{
    ITermRepository _repository;

    public TermController(ITermRepository repository)
    {
        _repository = repository;
    }

    public void CreateTerm()
    {
        Console.Write("Digite o termo: ");
        var term = Console.ReadLine()!.Replace("*", "").Replace("?", "");

        if (string.IsNullOrEmpty(term))
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        if (!string.IsNullOrEmpty(_repository.GetTermMeaning(term)))
        {
            Console.WriteLine("Termo já cadastrado!");
            return;
        }

        Console.Write("Digite o significado: ");
        var meaning = Console.ReadLine();

        _repository.AddTerm(term, meaning);
    }

    public void GetTerm()
    {
        Console.Write("Digite o termo: ");
        var term = Console.ReadLine()!.Replace("*", "").Replace("?", "");

        if (string.IsNullOrEmpty(term))
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        if (!string.IsNullOrEmpty(_repository.GetTermMeaning(term)))
        {
            Console.WriteLine($"Termo: {term} - Significado: {_repository.GetTermMeaning(term)}");
        }
        else
        {
            var termsFound = _repository.GetTerms(term);
            if (termsFound.Any())
            {
                Console.WriteLine("Termos encontrados:\n");
                foreach (var t in termsFound)
                {
                    Console.WriteLine($"Termo: {t.Key} - Significado: {t.Value}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum termo encontrado");
            }
        }
    }
}
