﻿using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.Infrastructure.Storage.Mappings;
using KingdomStrategy.UseCases;
using MongoDB.Driver;

namespace KingdomStrategy;

public static class Services
{
    static IConfigurationRoot Configure()
    {
        var directory = Directory.GetCurrentDirectory();
        var builder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json");

        var result = builder.Build();
        return result;
    }

    public static IServiceProvider Get()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IMediator, MessageMediator>();

        services.AddSingleton<KingdomRatingStorage>();

        services.AddSingleton<KingdomLeaderboard>();
        services.AddSingleton<KingdomStorage>();

        services.AddSingleton<TroopRatingRule>();
        services.AddSingleton<BuildingRule>();
        services.AddSingleton<KingdomRatingManager>(s => new KingdomRatingManager(
            new List<KingdomRatingRule>
            {
                s.GetRequiredService<TroopRatingRule>(),
                s.GetRequiredService<BuildingRule>(),
            }, s.GetRequiredService<IDateTimeProvider>(), s.GetRequiredService<IMediator>(),
            s.GetRequiredService<KingdomRatingStorage>()
        ));
        services.AddSingleton<KingdomMediatorFactory>();
        services.AddSingleton<KingdomBaseStorageFactory>();
        services.AddSingleton<KingdomSeed>();
        services.AddSingleton<KingdomLoader>();

        CollectionMappings.Init();
        var mappings = new List<FluentMapping>
        {
            new GoldMapping(),
            new FoodMapping(),
            new StoneMapping(),
            new WoodMapping(),
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

        var config = Configure();
        var connectionString = config.GetConnectionString("MongoDb");

        services.AddSingleton(c => new MongoClient(connectionString));
        services.AddSingleton<IMongoDatabase>(s =>
        {
            var client = s.GetRequiredService<MongoClient>();
            var dbName = MongoUrl.Create(connectionString).DatabaseName;
            return client.GetDatabase(dbName);
        });
        services.AddSingleton(s => config);

        services.AddSingleton<IMessageHandler<KingdomEvent>, KingdomEventMessageHandler>();
        services
            .AddSingleton<IMessageHandler<KingdomRatingRecalculatedEvent>, KingdomRatingRecalculatedMessageHandler>();
        services.AddSingleton<ILogWriter, LogWriter>();

        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes =>
            {
                classes.AssignableTo(typeof(IMessageHandler<>));
            })
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes =>
            {
                var res = classes.AssignableTo(typeof(IUseCase));
                return;
            })
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services.BuildServiceProvider();
    }
}