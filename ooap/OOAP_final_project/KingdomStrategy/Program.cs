using KingdomStrategy;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.Infrastructure.Storage.Mappings;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IMediator, MessageMediator>();
        
        services.AddSingleton<KingdomRatingStorage>();

        services.AddSingleton<KingdomLeaderboard>();
        services.AddSingleton<KingdomRatingManager>();
        services.AddSingleton<KingdomMediatorFactory>();
        services.AddSingleton<KingdomBaseStorageFactory>();
        
        CollectionMappings.Init();
        var mappings = new List<FluentMapping>
        {
            new StateMapping(),
            new ResourceManagerStateMapping(),
            new BuildingStateMapping(),
            new GoldMineStateMapping(),
            new ByKingdomStateMapping(),
            new TroopStateMapping(),
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
        
        services.Scan(scan => scan
            .FromExecutingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(KingdomBaseStorage<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
    })
    .Build();

host.Run();