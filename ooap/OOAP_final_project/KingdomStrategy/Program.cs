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
    foreach (var useCase in useCases)
    {
        Console.WriteLine(useCase.Command + " - " + useCase.Name);
    }
    Console.WriteLine("Type 'exit' or 'quit' to exit.");
            
    // Read user input
    Console.Write("> ");
    var input = Console.ReadLine()?.ToLowerInvariant();
    if (input == null)
    {
        Console.WriteLine("Invalid command.");
        continue;
    }
            
    if (input == "exit" || input == "quit")
    {
        Console.WriteLine("Goodbye!");
        return;
    }
            
    if (!int.TryParse(input, out int command))
    {
        Console.WriteLine("Invalid command.");
        continue;
    }
            
    // Find matching use case and run it
    var matchingUseCase = useCases.FirstOrDefault(u => u.Command == command);
    if (matchingUseCase == null)
    {
        Console.WriteLine("Invalid command.");
        continue;
    }
            
    Console.WriteLine($"Running {matchingUseCase.Name}...");
    await matchingUseCase.Run(input.Split(" "));
    Console.WriteLine("Done.");
}



