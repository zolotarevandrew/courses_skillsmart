namespace h_work.lesson47.example1;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

/*
public class AdditionalFiller
{

    public CalculatedChanges CalcChanges(
        DossierAdditionFillerContext context,
        CompanyPersonInStorage owner,
        List<CompanyPersonInStorage> persons)
    {
        var companyId = context.Company.Id;
        var ownerTypeOfRepresentation = owner
            .GetRepresentativeInBusinesses()
            .FirstOrDefault(c => c.BusinessId == context.Company.Id) ?? new LegalRepresentativeInBusiness
        {
            BusinessId = context.Company.Id,
            TypeOfLegalRepresentation = ETypeOfLegalRepresentation.None
        };

        var lrs = persons.Count(c => c.IsLegalRepresentative == true);
        if (ownerTypeOfRepresentation.TypeOfLegalRepresentation == ETypeOfLegalRepresentation.Unknown && lrs == 1)
        {
            if (persons.Count == 1)
            {
                var relation = new LegalRepresentativeBusinessRelation(companyId, ETypeOfLegalRepresentation.Solo);
                return new CalculatedChanges
                {
                    Persons = CalcUpdatedPersons(new List<CompanyPersonInStorage>
                    {
                        owner
                    }, context, relation),
                    Type = SpainFillerType.UnknownSetSolo
                };
            }

            var unconfirmed = new LegalRepresentativeBusinessRelation(
                companyId, 
                ETypeOfLegalRepresentation.Solo,
                ETypeOfLegalRepresentationStatus.Unconfirmed);
            return new CalculatedChanges
            {
                Persons = CalcUpdatedPersons(new List<CompanyPersonInStorage>
                {
                    owner
                }, context, unconfirmed),
                Type = SpainFillerType.UnknownSetSoloUnconfirmed
            };
        }
        if (ownerTypeOfRepresentation.TypeOfLegalRepresentation == ETypeOfLegalRepresentation.Unknown && lrs > 1)
        {
            var unconfirmed = new LegalRepresentativeBusinessRelation(
                companyId, 
                ETypeOfLegalRepresentation.Joint,
                ETypeOfLegalRepresentationStatus.Unconfirmed);
            return new CalculatedChanges
            {
                Persons = CalcUpdatedPersons(persons, context, unconfirmed),
                Type = SpainFillerType.UnknownSetJointUnconfirmed
            };
        }
        
        if (ownerTypeOfRepresentation.TypeOfLegalRepresentation == ETypeOfLegalRepresentation.Joint && persons.Count == 1)
        {
            return new CalculatedChanges
            {
                Persons = new List<CompanyPersonInStorage>(),
                Type = SpainFillerType.OnlyJointRegistrator
            };
        }

        if (ownerTypeOfRepresentation.TypeOfLegalRepresentation
            .In(ETypeOfLegalRepresentation.Solo, ETypeOfLegalRepresentation.Joint))
        {
            var otherPersons = persons
                .Where(c => c.Id != owner.Id)
                .ToList();
            var unconfirmed = new LegalRepresentativeBusinessRelation(
                companyId, 
                ETypeOfLegalRepresentation.Joint,
                ETypeOfLegalRepresentationStatus.Unconfirmed);
            return new CalculatedChanges
            {
                Persons = CalcUpdatedPersons(otherPersons, context, unconfirmed)
            };
        }

        return new CalculatedChanges
        {
            Persons = new List<CompanyPersonInStorage>()
        };
    }

    public class CalculatedChanges
    {
        public List<CompanyPersonInStorage> Persons { get; init; } = new List<CompanyPersonInStorage>();
        public SpainFillerType? Type { get; set; }
    }

    public enum SpainFillerType
    {
        UnknownSetSolo,
        UnknownSetSoloUnconfirmed,
        UnknownSetJointUnconfirmed,
        OnlyJointRegistrator,
        NoLrsReceived
    }

}
*/