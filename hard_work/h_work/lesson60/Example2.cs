
namespace Example2.Module1
{
    public record PhoneNumber(string Code, string Number);

    public record Email(string Value);

    public record User(string Id);
    public class SmsModels
    {
        public class Specific1Model1
        {
            
        }
    }
    
    public class EmailModels
    {
        public class Specific1Model1
        {
            
        }
    }
    
    public class PushModels
    {
        public class Specific1Model1
        {
            
        }
    }

    public interface ISmsService
    {
        Task Send(PhoneNumber number, SmsModels.Specific1Model1 model);
    }
    
    public interface IEmailService
    {
        Task Send(Email email, EmailModels.Specific1Model1 model);
    }

    public interface IPushService
    {
        Task Send(User user, PushModels.Specific1Model1 model);
    }

    public interface INotificationScope
    {
        ISmsService Sms { get; }
        IEmailService Email { get; }
        IPushService Push { get; }
    }

    public class Implementation : ISmsService, IEmailService, IPushService
    {
        Task ISmsService.Send(PhoneNumber number, SmsModels.Specific1Model1 model)
        {
            throw new NotImplementedException();
        }

        Task IEmailService.Send(Email email, EmailModels.Specific1Model1 model)
        {
            throw new NotImplementedException();
        }
        
        Task IPushService.Send(User user, PushModels.Specific1Model1 model)
        {
            throw new NotImplementedException();
        }
    }
}

