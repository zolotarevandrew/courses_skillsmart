namespace h_work.lesson31.example3;

public interface IOnboardingPusher
{
    Task Push(PushOnboardingDetailsMismatchModel model);
    Task Push(PushOnboardingReviewDetailsModel model);
    Task Push(PushOnboardingDuplicateDeclineModel model);
}

public class PushOnboardingDetailsMismatchModel
{
}

public class PushOnboardingDuplicateDeclineModel
{
}

public class PushOnboardingReviewDetailsModel
{
}

public interface IOnboardingPusherV2
{
    Task PushDetailsMismatch(PushOnboardingDetailsMismatchModel model);
    Task PushReviewDetails(PushOnboardingReviewDetailsModel model);
    Task PushDuplicateDecline(PushOnboardingDuplicateDeclineModel model);
}
