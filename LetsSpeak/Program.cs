using LetsSpeak.Controllers;
using LetsSpeak.Repositories;

namespace LetsSpeak;

public class Program
{
    static void Main()
    {
        DatabaseInitializer.Initialize();
        
        var title = "Let's Speak!";
        Console.Title = title;

        var termController = new TermController(new TermRepository());

        var menu = new Menu(title);
        menu.Add(new Menu("Adicionar termo", termController.CreateTerm));
        menu.Add(new Menu("Consultar termo", termController.GetTerm));

        menu.Execute();
    }
}