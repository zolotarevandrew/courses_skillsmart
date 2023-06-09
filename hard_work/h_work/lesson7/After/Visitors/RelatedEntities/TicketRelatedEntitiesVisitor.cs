using h_work.lesson7.Before;

namespace h_work.lesson7.After.Visitors.RelatedEntities;

public class TicketRelatedEntitiesVisitor : ITicketVisitor
{
    private readonly CheckInfoMember _checkInfoMember;
    public List<TicketRelatedEntity> Value { get; }

    public TicketRelatedEntitiesVisitor(CheckInfoMember checkInfoMember)
    {
        _checkInfoMember = checkInfoMember;
        Value = new List<TicketRelatedEntity>();
    }
    
    public async Task Visit(CompanyTicketServiceV2 companyTicket)
    {
        var relatedEntities = new CompanyTicketRelatedEntities(companyTicket);
        var value = await relatedEntities.Get(_checkInfoMember);
        Value.AddRange(value);
    }

    public async Task Visit(OrgStructureTicketServiceV2 orgStructureTicket)
    {
        var relatedEntities = new OrgStructureTicketRelatedEntities(orgStructureTicket);
        var value = await relatedEntities.Get(_checkInfoMember);
        Value.AddRange(value);
    }
}