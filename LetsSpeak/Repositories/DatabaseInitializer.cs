namespace LetsSpeak.Repositories;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        try
        {
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "terms.json");

            if (!File.Exists(file))
            {
                File.Create(file).Close();
                File.WriteAllText(file, "{}");
            }
        }
        catch (Exception ex)
        {
            Console.Write("Erro: " + ex.Message);
            Console.ReadLine();
        }
    }
}
