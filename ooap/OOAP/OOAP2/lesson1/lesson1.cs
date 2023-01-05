using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOAP2.lesson1
{
    public class SendMessageProps
    {
        public Guid UserId { get; set; }
        public Dictionary<string, string> Variables { get; set; } = new();
    }

    public interface IUserInfoGetter
    {
        Task<string> GetFullName(Guid userId);
    }

    public class BuildMessageProps
    {
        public string UserName { get; set; }
    }

    public enum SlackChannel
    {
        New = 1,
        Updates = 2
    }

    public interface ISlackSender
    {
        Task Send(SlackChannel channel, string msg);
    }
    
    public abstract class SlackTypedNotification
    {
        private readonly IUserInfoGetter _userInfoGetter;
        private readonly ISlackSender _slackSender;

        public SlackTypedNotification(IUserInfoGetter userInfoGetter, ISlackSender slackSender)
        {
            _userInfoGetter = userInfoGetter;
            _slackSender = slackSender;
        }
        
        public async Task Send(SendMessageProps props)
        {
            var userId = props.UserId;
            var userName = await _userInfoGetter.GetFullName(userId);
            var message = await BuildMessage(new BuildMessageProps
            {
                UserName = userName
            });

            await _slackSender.Send(Channel, message);
        }

        protected abstract SlackChannel Channel { get; }
        protected abstract Task<string> BuildMessage(BuildMessageProps props);
    }
    
    //наследование с 1 уровнем
    public class NewItemAddedSlackNotifier : SlackTypedNotification
    {
        public NewItemAddedSlackNotifier(IUserInfoGetter userInfoGetter, ISlackSender slackSender) : base(userInfoGetter, slackSender)
        {
        }

        protected override SlackChannel Channel => SlackChannel.New;
        protected override async Task<string> BuildMessage(BuildMessageProps props)
        {
            await Task.CompletedTask;
            return "New item added";
        }
    }
    
    //наследование с 2 уровнями
    public class NewItemAddedWithChangesSlackNotifier : NewItemAddedSlackNotifier
    {
        public NewItemAddedWithChangesSlackNotifier(IUserInfoGetter userInfoGetter, ISlackSender slackSender) : base(userInfoGetter, slackSender)
        {
        }

        protected override SlackChannel Channel => SlackChannel.Updates;
        protected override async Task<string> BuildMessage(BuildMessageProps props)
        {
            var baseMsg = await base.BuildMessage(props);
            return baseMsg + ". With some changes";
        }
    }

    public enum NotifyType
    {
        NewItemAdded = 1,
        NewItemAddedWithChanges = 2
    }

    public class NotificationSender
    {
        //полиморфизм
        private readonly SlackTypedNotification _newItemAddedWithChangesSlackNotifier;
        private readonly SlackTypedNotification _newItemAddedSlackNotifier;

        //композиция
        public NotificationSender(NewItemAddedSlackNotifier newItemAddedSlackNotifier, NewItemAddedWithChangesSlackNotifier newItemAddedWithChangesSlackNotifier)
        {
            _newItemAddedSlackNotifier = newItemAddedSlackNotifier;
            _newItemAddedWithChangesSlackNotifier = newItemAddedWithChangesSlackNotifier;
        }

        public async Task Send(NotifyType type, SendMessageProps props)
        {
            if (type == NotifyType.NewItemAdded)
            {
                await _newItemAddedSlackNotifier.Send(props);
                return;
            }
            if (type == NotifyType.NewItemAddedWithChanges)
            {
                await _newItemAddedWithChangesSlackNotifier.Send(props);
                return;
            }

            throw new NotImplementedException();
        }
    }
    
    
    
    
}