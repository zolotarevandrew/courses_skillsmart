namespace h_work.lesson36;

/*
 * public class DefaultExecuteStepService : BaseExecuteStepService
    {
        protected readonly IDefaultExecuteStepServiceDependencies _dependencies;

        public DefaultExecuteStepService(
            IDefaultExecuteStepServiceDependencies dependencies)
            : base(dependencies)
        {
            _dependencies = dependencies;
        }

        protected override async Task Execute<T>(IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, T contract)
        {
            await StoreData(stepContext, contract);

            await base.Execute(context, stepContext, contract);
        }

        protected Task StoreData<T>(BankOnboardingStepContext stepContext, T contract)
        {
            return _dependencies.Publisher.PublishAsync(new StoreDataMessage
            {
                Sid = stepContext.Sid,
                Data = new Interfaces.OnboardingSteps.BankOnboardingStepData
                {
                    Timestamp = DateTime.UtcNow,
                    Value = contract,
                },
                ClientInfo = stepContext.ClientInfo,
            });
        }
    }
    
    public abstract class BaseExecuteStepService : BaseStepService,
        IBankOnboardingExecuteStepService
    {
        private readonly IExecuteStepServiceDependencies _dependencies;
        private readonly string _source;

        protected BankOnboardingStepActionContext ActionContext { get; private set; }

        protected BaseExecuteStepService(
            IExecuteStepServiceDependencies dependencies)
        {
            _dependencies = dependencies;
            _source = GetType().Name;
        }

        protected virtual Task Execute<T>(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, T contract)
        {
            return Task.CompletedTask;
        }

        protected virtual Task<BankOnboardingExecuteStepResult> ExecuteResult<T>(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, T contract)
        {
            return Task.FromResult(new BankOnboardingExecuteStepResult { });
        }

        protected virtual Task ValidateContract<T>(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, T contract)
        {
            return Task.CompletedTask;
        }

        protected virtual Task NextStepDefined(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext,
            BankOnboardingStepContext nextStepContext)
        {
            return Task.CompletedTask;
        }

        protected virtual Task<bool> AllowValidate(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext)
        {
            bool result = !context.OnboardingStatus.In(BankOnboardingStatuses.NotAllowValidate);

            return Task.FromResult(result);
        }

        protected virtual Task<bool> SkipExecute(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext)
        {
            bool result = KycInited(context)
                && stepContext.CurrentStatus == EBankOnboardingStepStatus.Completed;

            return Task.FromResult(result);
        }

        async Task<BankOnboardingExecuteStepResult> IBankOnboardingExecuteStepService.Execute(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, object contract,
            BankOnboardingStepActionContext actionContext)
        {
            
        }

        async Task IBankOnboardingExecuteStepService.ValidateContract(
            IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, object contract,
            BankOnboardingStepActionContext actionContext)
        {
           
        }

        Task IBankOnboardingExecuteStepService.NextStepDefined(IBankOnboardingContext context,
            BankOnboardingStepContext stepContext, BankOnboardingStepContext nextStepContext,
            BankOnboardingStepActionContext actionContext)
        {
            
        }
    }
    
    public abstract class BaseStepService
    {
        public string UserCurrentLang { get; set; } = Consts.DefaultLanguage;

        private readonly Dictionary<string, object> _storage = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                if (_storage.ContainsKey(key))
                {
                    return _storage[key];
                }

                return null;
            }
            set => _storage[key] = value;
        }

        protected static JsonSerializerSettings SerializerSettings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        };

        protected static bool KycInited(IBankOnboardingContext context)
        {
          
        }

        protected static bool ApplicationSent(IBankOnboardingContext context)
        {
           
        }

        protected static bool IsIssueStatus(BankOnboardingStepContext stepContext)
        {
          }

        protected static bool IsDataSentToPartners(IBankOnboardingContext context)
        {
         
        }

        protected static bool IsNotAllowGetData(IBankOnboardingContext context)
        {
          
        }

        protected static bool KycInitedOrIsNotAllowGetData(IBankOnboardingContext context)
        {
           
        }

        //allowed to return even from error steps
        protected static bool IsNotAllowedToReturnOnStep(IBankOnboardingContext context)
        {
           
        }

        protected static bool FirstPhaseCapitalDepositComplete(IBankOnboardingContext context)
        {
          
        }

        protected virtual async Task<bool> IsCapitalDepositUserCreated(IBankOnboardingContext context,
            IBankOnboardingService bankOnboardingService)
        {
            
        }
    }
*/