namespace h_work.lesson13.example1;


public interface IDossierEditor : IAsyncDisposable
{
    Task Run(EditDossierDelegate @delegate);
}

public delegate Task EditDossierDelegate(IDbConnection connection, IDbTransaction transaction, DossierQuestionnaireEditionContext context);

public interface IDossierEditorFactory
{
    Task<IDossierEditor> Create(DossierQuestionnaireEditionContext context);
}

public class DossierEditorFactory : IDossierEditorFactory
{
    private readonly IDbConnector _dbConnector;
    private readonly IPublisher _publisher;
    private readonly IDataSourceStorageService _dataSourceStorageService;

    public DossierEditorFactory(IDbConnector dbConnector, IPublisher publisher, IDataSourceStorageService dataSourceStorageService)
    {
        _dbConnector = dbConnector;
        _publisher = publisher;
        _dataSourceStorageService = dataSourceStorageService;
    }

    public async Task<IDossierEditor> Create(DossierQuestionnaireEditionContext context)
    {
        var connection = await _dbConnector.OpenConnection(CancellationToken.None);
        var transaction = connection.BeginTransaction();

        var editor = new DossierEditor(_publisher, transaction, connection, context, _dataSourceStorageService);
        return editor;
    }

    class DossierEditor : IDossierEditor
    {
        private readonly IPublisher _publisher;
        private readonly IDataSourceStorageService _dataSourceStorageService;

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private DossierQuestionnaireEditionContext _context;

        private bool _isFailed;
        private bool _isDisposed;

        public DossierEditor(
            IPublisher publisher,
            IDbTransaction dbTransaction,
            IDbConnection dbConnection,
            DossierQuestionnaireEditionContext context, IDataSourceStorageService dataSourceStorageService)
        {
            _publisher = publisher;
            _transaction = dbTransaction;
            _connection = dbConnection;
            _context = context;
            _dataSourceStorageService = dataSourceStorageService;
        }

        public async ValueTask DisposeAsync()
        {
            if (_isDisposed) return;

            _connection.Dispose();
            _transaction.Dispose();

             _isDisposed = true;

            await TrySendLogs();
        }

        async Task TrySendLogs()
        {
            if (_isFailed) return;

            var logTasks = _context
                .ValueChangedLogsToStore
                .Select(storeLogMessage => _publisher.Publish(storeLogMessage))
                .ToList();

            await Task.WhenAll(logTasks);
        }

        public async Task Run(EditDossierDelegate @delegate)
        {
            try
            {
                await @delegate(_connection, _transaction, _context);
                await _dataSourceStorageService.Upsert(_connection, _transaction, _context.DataSources);

                _transaction.Commit();
                _isFailed = false;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                _isFailed = true;
                throw;
            }
        }

    }
}



public class ExampleUsing
{
    private readonly IDossierEditorFactory _editorFactory;
    private readonly IPublisher _publisher;

    public ExampleUsing(IDossierEditorFactory editorFactory, IPublisher publisher)
    {
        _editorFactory = editorFactory;
        _publisher = publisher;
    }

    public async Task Run()
    {
        var requestContext = new InternalRequestContext();
        var context = new DossierQuestionnaireEditionContext(requestContext);
        context.TryAddData(nameof(DateTime.UtcNow), DateTime.UtcNow);

        await using (var editor = await _editorFactory.Create(context))
        {
            await editor.Run(InternalEdit);
        }

        await CustomMessage(context);
    }

    Task CustomMessage(DossierQuestionnaireEditionContext context)
    {
        if (!context.IsChanged) return Task.CompletedTask;
        {
            return _publisher.Publish(new
            {
                CustomMessage = true
            });
        }
    }

    Task InternalEdit(IDbConnection dbConnection, IDbTransaction transaction, DossierQuestionnaireEditionContext context)
    {
        //adding custom logic ere
        return Task.CompletedTask;
    }
}
