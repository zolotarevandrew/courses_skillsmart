namespace h_work.lesson81;

/*
public enum GroupIbPhoneAlertGroup
{
    All,
    Triggered
}
public class GroupIbByPhoneTrigger : SimpleSkipTaskTriggerBase
{
    private readonly GroupIbAlertsResponse _response;
    private readonly GroupIbTypedAlertContext _context;
    private readonly IGroupIbTypedAlertFactory _typedAlertFactory;
    public GroupIbByPhoneTrigger(
        GroupIbAlertsResponse response, 
        IGroupIbTypedAlertFactory typedAlertFactory, 
        GroupIbTypedAlertContext context)
    {
        _response = response;
        _typedAlertFactory = typedAlertFactory;
        _context = context;
    }
    
    public Dictionary<GroupIbPhoneAlertGroup, List<GroupIbAlertItem>> Alerts { get; private set; }

    protected override async Task CheckInternal()
    {
        var phoneAlerts = await GetPhoneAlerts();
        Alerts[GroupIbPhoneAlertGroup.Triggered] = phoneAlerts.Where(c => c.TriggerReason.Trigger).ToList();
        Alerts[GroupIbPhoneAlertGroup.All] = phoneAlerts.Select(c => new GroupIbAlertItem
        {
            TypeId = c.TypeId,
            TypeTitle = c.TypeTitle
        }).ToList();
    }

    private async Task<List<GroupIbAlertItem>> GetPhoneAlerts()
    {
        var res = new List<GroupIbAlertItem>();
        return res;
    }
}
*/