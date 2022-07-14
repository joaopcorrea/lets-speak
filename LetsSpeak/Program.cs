using Microsoft.Extensions.DependencyInjection;

using LetsSpeak.Controllers;
using LetsSpeak.Repositories;
using LetsSpeak.Repositories.Interfaces;
using LetsSpeak.Controllers.Interfaces;

namespace LetsSpeak;

public class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection()
            .AddScoped<ITermController, TermController>()
            .AddScoped<ITermRepository, TermRepository>();

        DatabaseInitializer.Initialize();
        
        var title = "Let's Speak!";
        Console.Title = title;

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var termController = serviceProvider.GetService<ITermController>();

        var menu = new Menu(title);
        menu.Add(new Menu("Adicionar termo", termController.CreateTerm));
        menu.Add(new Menu("Consultar termo", termController.GetTerm));

        menu.Execute();
    }
}