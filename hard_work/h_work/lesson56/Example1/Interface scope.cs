namespace h_work.lesson56.Example1;

public class OnboardingNotificationService :
    IOnboardingEmailNotificationService,
    IOnboardingSmsNotificationService
{

    #region Emails

    public Task IOnboardingEmailNotificationService.SendOnboardingWaitListed(FinomEmail email, OnboardingWaitListedEmailModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendVerificationLinkToNonRegistrator(FinomEmail email, EmailVerificationLinkToNonRegistratorModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendToRegistrarPersonalVerificationRepeat(
        FinomEmail email, EmailToRegistrarPersonalVerificationRepeatModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendPersonalVerificationRepeat(FinomEmail email,
        EmailPersonalVerificationRepeatModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendReverificationRequested(FinomEmail email,
        EmailReverificationRequestedModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendVerificationNotCompleted(FinomEmail email,
        EmailVerificationNotCompletedModel notCompletedModel)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendVerifyPersonModel(FinomEmail email, EmailVerifyPersonModel model)
    {
        
    }

    async Task IOnboardingEmailNotificationService.SendSumSubIdentificationRepeat(FinomEmail email, EmailSumSubIdentificationRepeatModel model)
    {
       
    }

    async Task IOnboardingEmailNotificationService.SendActionRequired(FinomEmail email, EmailActionRequiredModel model)
    {
        
    }

    public async Task IOnboardingEmailNotificationService.SendAdditionalQuestions(FinomEmail email, EmailAdditionalQuestionsModel model)
    {
        
    }

    public async Task IOnboardingEmailNotificationService.SendOnboardingApproved(FinomEmail email, OnboardingApprovedEmailModel model)
    {
        
    }

    public async Task IOnboardingEmailNotificationService.SendTaxIdentificationRemind(FinomEmail email, FinomTaxIdentificationEmailModel model)
    {
        
        
    }


    public Task IOnboardingEmailNotificationService.SendTaxIdentificationActionRequired(FinomEmail email, FinomTaxIdentificationActionRequiredEmailModel model)
    {
       

        
    }

    public async Task IOnboardingEmailNotificationService.SendDataCollectionRemind(FinomEmail email, FinomDataCollectionRemindEmailModel model)
    {
        

        
    }

    #endregion

    #region Sms

    async Task IOnboardingSmsNotificationService.SendVerificationLinkToNonRegistrator(MobilePhone phone, SmsVerificationLinkToNonRegistratorModel model)
    {
        
    }

    async Task IOnboardingSmsNotificationService.SendOwnVerificationLink(MobilePhone phone, SendOwnVerificationLinkModel model)
    {
       
    }

    async Task IOnboardingSmsNotificationService.SendAdditionalQuestionsRequiredLink(MobilePhone phone, SmsAnswersRequiredModel model)
    {
       
    }

    async Task IOnboardingSmsNotificationService.SendAccountPreApproved(MobilePhone phone, SmsAccountPreApprovedModel model)
    {
       
    }

    async Task IOnboardingSmsNotificationService.SendPersonVerificationLink(MobilePhone phone, SendPersonVerificationLinkModel model)
    {
        
    }

    async Task IOnboardingSmsNotificationService.SendPersonVerificationFailed(MobilePhone phone,
        SmsPersonVerificationFailedModel model)
    {
        
        
    }

    async Task IOnboardingSmsNotificationService.SendOwnVerificationFailed(MobilePhone phone,
        SmsVerificationFailedModel model)
    {
       
    }

    #endregion
    
}