using h_work.lesson7.Before;

namespace h_work.lesson7.After.Visitors.RelatedEntities;

public class OrgStructureTicketRelatedEntities
{
    private readonly OrgStructureTicketServiceV2 _orgStructureTicket;

    public OrgStructureTicketRelatedEntities(OrgStructureTicketServiceV2 orgStructureTicket)
    {
        _orgStructureTicket = orgStructureTicket;
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
            var resultItem = new TicketRelatedEntity
            {
                EntityId = member.EntityId.ToString(),
                EntityType = member.EntityType,
                Properties = new List<TicketRelatedEntityProperty>
                    {
                        new ()
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
                            PropertyType = ERelatedEntityPropertyType.CountryOfResidence,
                            Value = member.Country,
                        },
                    },
            };

            if (member?.IsLegalRepresentative == true)
            {
                result.Add(resultItem with { RelatedType = ERelatedType.LegalRepresentatives });
            }

            if (member?.IsBeneficiary == true)
            {
                result.Add(resultItem with { RelatedType = ERelatedType.Ubos });
            }

            if (member?.IsShareholder == true)
            {
                result.Add(resultItem with { RelatedType = ERelatedType.Shareholders });
            }
        }

        if (member?.EntityType == EEntityType.LegalEntity)
        {
            if (member.IsLegalRepresentative == true)
            {
                result.Add(new TicketRelatedEntity
                {
                    EntityId = member.EntityId.ToString(),
                    EntityType = member.EntityType,
                    RelatedType = ERelatedType.LegalRepresentatives,
                    Properties = new List<TicketRelatedEntityProperty>
                    {
                        new ()
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

            if (member.IsShareholder == true)
            {
                result.Add(new TicketRelatedEntity
                {
                    EntityId = member.EntityId.ToString(),
                    EntityType = member.EntityType,
                    RelatedType = ERelatedType.Shareholders,
                    Properties = new List<TicketRelatedEntityProperty>
                    {
                        new ()
                        {
                            PropertyType = ERelatedEntityPropertyType.BusinessName,
                            Value = member.Name,
                        },
                        new()
                        {
                            PropertyType = ERelatedEntityPropertyType.CountryOfIncorporation,
                            Value = member.Country,
                        },
                        new()
                        {
                            PropertyType = ERelatedEntityPropertyType.LegalForm,
                            Value = member.LegalForm,
                        },
                    },
                });
            }
        }
    }
}