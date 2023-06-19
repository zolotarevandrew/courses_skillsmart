

using h_work.lesson9.example6;

namespace h_work.lesson5.example1
{
    public delegate InternalStateMachine StepTransitionMachineDelegate(StepTransitionContext context);
    
    /// <summary>
    /// Умная машина переходов между шагами онбординга - одна из самых важных частей онбординга
    
    /// 1) Переходы между шагами на разных типах онбординга связаны различными условиями и они достаточно сложные
    /// 2) Некоторые шаги приходится пропускать и выбирать следующий доступный для запроса данных клиента
    /// 3) Каждый переход описывается - одним или несколькими триггерами (условиями)
    /// 4) Для более выразительного описания переходов, когда несколько веток имеют различное ветвление и потом где-то сходятся вместе,
    /// лучше всего переходить на фейковое состояние не заданное шагом (а просто задаем ее строкой) - читаемость и поддерживаемость флоу кратно улучшается.
    /// 5) Помогает избавиться от "тупого прописывания if-ов на каждый переход" и позволяет переиспользовать и легко создавать новые версии Флоу онбординга.
    /// 
    /// 
    /// Важно понимать, что после разработки реализации данного класса, нужно экспортировать полученный результат и проверять как оно реально выглядит
    /// И действительно ли совпадает с условиями, описанными в ТЗ. Визуализация помогает бороться с неявностью и багами. 
    /// </summary>
    public abstract class StepTransitionMachine
    {
        private readonly IStepTransitionTriggerFactory _triggerFactory;
        private readonly StepTransitionMachineDelegate _delegate;

        protected StepTransitionMachine(IStepTransitionTriggerFactory triggerFactory)
        {
            _triggerFactory = triggerFactory;
            _delegate = Configure();
        }

        protected StepTransitionMachineDelegate Configure()
        {
            return ConfigureInternal();
        }

        protected abstract StepTransitionMachineDelegate ConfigureInternal();

        public async Task<EStep?> GetStep<TContext>(TContext context)
            where TContext : StepTransitionContext
        {
            var machine = CreateMachine(context);

            var queue = new Queue<InternalStepState>();
            var visitedStates = new HashSet<InternalStepState>();

            queue.Enqueue(machine.State);
            visitedStates.Add(machine.State);

            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                machine.ToState(state);

                var triggers = GetTriggers(machine);
                foreach (var trigger in triggers)
                {
                    await trigger.Value.CheckAsync(context);
                    var byTriggerState = trigger.Transition.State;

                    //we are always skipping states (states only for transitions)
                    if (trigger.Value.IsPassed && byTriggerState.IsStep)
                    {
                        return byTriggerState.Step;
                    }

                    if (visitedStates.Contains(byTriggerState)) continue;

                    queue.Enqueue(byTriggerState);
                    visitedStates.Add(byTriggerState);
                }
            }

            return null;
        }

        private IEnumerable<CustomTrigger> GetTriggers(InternalStateMachine machine)
        {
            var permitted = machine.PermittedTriggers();
            foreach (var transition in permitted)
            {
                var trigger = _triggerFactory.Get(transition.Trigger);
                if (trigger == null)
                {
                    throw new InvalidOperationException(transition.Trigger.Name + " was not found");
                }
                yield return new CustomTrigger(trigger, transition);
            }
        }

        InternalStateMachine CreateMachine(StepTransitionContext context)
        {
            var stateMachine = _delegate.Invoke(context);
            return stateMachine;
        }

        class CustomTrigger
        {
            public CustomTrigger(StepTransitionTrigger value, InternalStepTransition transition)
            {
                Transition = transition;
                Value = value;
            }

            public StepTransitionTrigger Value { get; }
            public InternalStepTransition Transition { get; }
        }
    }

    public class InternalStepState
    {
        public bool IsStep { get; set; }
        public EStep? Step { get; set; }
    }

    public class InternalStepTransition
    {
        public InternalStepState State { get; set; }
        public Type Trigger { get; set; }
    }

    public class StepTransitionTrigger
    {
        public async Task CheckAsync<TContext>(TContext context) where TContext : StepTransitionContext
        {
            throw new NotImplementedException();
        }

        public bool IsPassed { get; set; }
    }

    public class StepTransitionContext
    {
        public EBankOnboardingStep Step { get; set; }
    }

    public interface IStepTransitionTriggerFactory
    {
        StepTransitionTrigger Get(object trigger);
    }
    
    public class InternalStateMachine
    {
        public InternalStepState State { get; set; }

        public void ToState(InternalStepState state)
        {
            State = state;
        }

        public IEnumerable<InternalStepTransition> PermittedTriggers()
        {
            throw new NotImplementedException();
        }
    }
    
    public enum EStep 
    {
    
    }
}