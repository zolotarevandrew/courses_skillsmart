namespace h_work.lesson66;

public class Example1
{
    /*
     public async Task<EBankOnboardingStep?> GetStep<TContext>(TContext context)
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

                if (trigger.Value.IsPassed)
                {
                    queue.Enqueue(byTriggerState);
                    visitedStates.Add(byTriggerState);
                    break;
                }
            }
        }

        return null;
    }
     */
}