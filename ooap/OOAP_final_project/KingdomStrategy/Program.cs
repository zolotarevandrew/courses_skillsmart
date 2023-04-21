using KingdomStrategy;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;
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
        services.AddSingleton<KingdomStorage>();
        
        services.AddSingleton<TroopRatingRule>();
        services.AddSingleton<KingdomRatingManager>(s => new KingdomRatingManager(
            new List<KingdomRatingRule>
            {
                s.GetRequiredService<TroopRatingRule>()
            }, s.GetRequiredService<IDateTimeProvider>(), s.GetRequiredService<IMediator>()
        ));
        services.AddSingleton<KingdomMediatorFactory>();
        services.AddSingleton<KingdomBaseStorageFactory>();
        services.AddSingleton<KingdomSeed>();
        services.AddSingleton<KingdomLoader>();
        
        CollectionMappings.Init();
        var mappings = new List<FluentMapping>
        {
            new StateMapping(),
            new ResourceManagerStateMapping(),
            new BuildingStateMapping(),
            new GoldMineStateMapping(),
            new ByKingdomStateMapping(),
            new TroopStateMapping(),
            new KingdomMapping()
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

        services.AddSingleton<IMessageHandler<KingdomEvent>, KingdomEventMessageHandler>();
        services.AddSingleton<IMessageHandler<KingdomRatingRecalculatedEvent>, KingdomRatingRecalculatedMessageHandler>();
        
        services.Scan(scan => scan
            .FromExecutingAssembly()
            .AddClasses(classes =>
            {
                var res = classes.AssignableTo(typeof(IMessageHandler<>));
                return;
            })
            .AsImplementedInterfaces()
            .WithTransientLifetime());

    })
    .Build();

host.Run();