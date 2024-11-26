namespace h_work.lesson82.Example5;

/*
 public abstract class BaseGetDataStepService : BaseStepService,
        IBankOnboardingGetDataStepService
    {
        private readonly IBaseGetDataStepServiceDependencies _dependencies;
        private readonly string _source;

        protected virtual bool? IsShowCloseButton => null;

        protected virtual bool LogResult => false;

        protected BaseGetDataStepService(IBaseGetDataStepServiceDependencies dependencies)
        {
            _dependencies = dependencies;
            _source = GetType().Name;
        }

        protected virtual Task<object> GetData(IBankOnboardingContext context,
            BankOnboardingStepContext stepContext)
        {
            object result = new { };

            return Task.FromResult(result);
        }

        protected virtual Task<BankOnboardingStepContract> GetPrevStep(
            IBankOnboardingContext context, BankOnboardingStepContext stepContext)
        {
            BankOnboardingStepContract result = null;
            return Task.FromResult(result);
        }

        protected virtual Task<bool?> ShowCloseButton(IBankOnboardingContext context,
            BankOnboardingStepContext stepContext)
        {
            return Task.FromResult(IsShowCloseButton);
        }
    }
*/