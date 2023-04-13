using KingdomStrategy;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPublisher, MessagePublisher>();
        services.AddSingleton<KingdomRatingStorage>();
        
        services.AddSingleton<KingdomLeaderboard>();
        services.AddSingleton<KingdomRatingManager>();
        
        services.Scan(scan => scan
            .FromExecutingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IMessageHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
    })
    .Build();

host.Run();