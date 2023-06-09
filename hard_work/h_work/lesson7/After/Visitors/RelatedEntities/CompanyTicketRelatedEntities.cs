using h_work.lesson7.Before;

namespace h_work.lesson7.After.Visitors.RelatedEntities;

public class CompanyTicketRelatedEntities
{
    private readonly CompanyTicketServiceV2 _companyTicket;

    public CompanyTicketRelatedEntities(CompanyTicketServiceV2 companyTicket)
    {
        _companyTicket = companyTicket;
    }

    public async Task<IEnumerable<TicketRelatedEntity>> Get(CheckInfoMember? member)
    {
        List<TicketRelatedEntity> result = new();
        
        if (member == null) return result;

        if (member.EntityType == EEntityType.Company)
        {
            result.Add(new TicketRelatedEntity
            {
                EntityId = member.EntityId.ToString(),
                EntityType = member.EntityType,
                Properties = new List<TicketRelatedEntityProperty>
                {
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.BusinessName,
                        Value = member.Name,
                    },
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.CountryOfIncorporation,
                        Value = member.Country,
                    },
                },
            });
        }

        if (member.EntityType == EEntityType.Person)
        {
            result.Add(new TicketRelatedEntity
            {
                EntityId = member.EntityId.ToString(),
                EntityType = member.EntityType,
                Properties = new List<TicketRelatedEntityProperty>
                {
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.FullName,
                        Value = member.Name,
                    },
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.CompanyRole,
                        Value = member.Role,
                    },
                },
            });
        }

        if (member.EntityType == EEntityType.LegalEntity)
        {
            result.Add(new TicketRelatedEntity
            {
                EntityId = member.EntityId.ToString(),
                EntityType = member.EntityType,
                Properties = new List<TicketRelatedEntityProperty>
                {
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.FullName,
                        Value = member.Name,
                    },
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.CompanyRole,
                        Value = member.Role,
                    },
                    new()
                    {
                        PropertyType = ERelatedEntityPropertyType.CountryOfIncorporation,
                        Value = member.Country,
                    },
                },
            });
        }

        return result;
    }
}