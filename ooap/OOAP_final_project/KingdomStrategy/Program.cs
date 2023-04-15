using KingdomStrategy;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.Infrastructure.Storage.Mappings;
using MongoDB.Driver;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPublisher, MessagePublisher>();
        
        services.AddSingleton<KingdomRatingStorage>();
        services.AddSingleton<KingdomStorage>();
        
        services.AddSingleton<KingdomLeaderboard>();
        services.AddSingleton<KingdomRatingManager>();
        
        CollectionMappings.Init();
        var mappings = new List<FluentMapping>
        {
            new KingdomEntityMapping()
        };
        foreach (var mapping in mappings)
        {
            CollectionMappings.Add(mapping);
        }
        
        var connectionString = hostContext.Configuration.GetConnectionString("MongoDb");
        
        services.AddSingleton(c => new MongoClient(connectionString));
        services.AddSingleton<IMongoDatabase>(s =>
        {
            var client = s.GetRequiredService<MongoClient>();
            var dbName = MongoUrl.Create(connectionString).DatabaseName;
            return client.GetDatabase(dbName);
        });
        
        services.Scan(scan => scan
            .FromExecutingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IMessageHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
    })
    .Build();

host.Run();