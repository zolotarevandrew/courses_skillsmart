using KingdomStrategy;
using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.UseCases;

var services = Services.Get();
var seed = services.GetRequiredService<KingdomSeed>();
await seed.Seed();

var useCases = services
    .GetServices<IUseCase>()
    .OrderBy( c => c.Command);

Console.WriteLine("Hello to Kingdom Strategy Game. Choose an option:");

while (true)
{
    Console.WriteLine("Type 'h' or 'help' to get help.");
    Console.WriteLine("Type 'exit' or 'quit' to exit.");
            
    // Read user input
    Console.Write("> ");
    var input = Console.ReadLine();
    var splitted = input.Split(" ");
    if (input == null || splitted.Length == 0)
    {
        Console.WriteLine("Invalid command.");
        continue;
    }

    var lower = input.ToLowerInvariant();
    if (lower == "exit" || lower == "quit")
    {
        Console.WriteLine("Goodbye!");
        return;
    }
    
    if (lower == "h" || lower == "help")
    {
        foreach (var useCase in useCases)
        {
            Console.WriteLine(useCase.Command + " - " + useCase.Help);
        }
        continue;
    }

    // Find matching use case and run it
    var cmd = splitted[0];
    var matchingUseCase = useCases.FirstOrDefault(u => u.Command.ToString() == cmd);
    if (matchingUseCase == null)
    {
        Console.WriteLine("Invalid command.");
        continue;
    }
    
    var arguments = splitted.Length > 1 ? splitted[1..] : new string[] { };
    await matchingUseCase.Run(arguments);
}



