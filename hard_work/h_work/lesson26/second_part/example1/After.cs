using System;

namespace h_work.lesson26.second_part.example1
{
    public interface IVerifiedPersonServiceV2
    {
        Task<UserVerifiedPersonsGroup> Get(Guid userId);
    }
    
    public interface IPerson
    {
        PersonFullName FullName { get; }
        DateTime? DateOfBirth { get; }
    }
    
    public record PersonFullName(string First, string Last);
    public class UserVerifiedPerson : IPerson
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Nationality { get; init; }
        public PersonFullName FullName => new(FirstName, LastName);
        public DateTime? DateOfBirth { get; init; }
        public string CountryOfBirth { get; init; }
        public string PlaceOfBirth { get; init; }
        public Guid Company { get; init; }
    }

    public class UserVerifiedPersonsGroup
    {
        public List<UserVerifiedPerson> Value { get; }
        public UserVerifiedPerson Rvp => Value.FirstOrDefault();
        public bool Any => Value.Any();

        public Guid UserId { get; }

        public UserVerifiedPersonsGroup(Guid userId, List<UserVerifiedPerson> persons)
        {
            Value = persons;
            UserId = userId;
        }

        public async Task<bool> AreAllSame(IPersonComparer comparer)
        {
            if (Value.Count == 0) return false;
            if (Value.Count == 1) return true;

            for (int i = 0; i < Value.Count - 1; i++)
            {
                for (int j = i + 1; j < Value.Count; j++)
                {
                    var person1 = Value[i];
                    var person2 = Value[j];

                    var comparisonResult = await comparer.Compare(person1, person2);

                    if (!comparisonResult.IsFullMatch) return false;
                }
            }

            return true;
        }

        public async Task<T> MatchWithRvp<T>(IPersonComparer comparer, List<T> persons)
            where T : IPerson
        {
            var rvp = Rvp;
            if (rvp == null) return default;

            foreach (var person in persons)
            {
                var comparedPersons = await comparer.Compare(person, rvp);
                if (comparedPersons.IsFullMatch) return person;
            }

            return default;
        }
    }

    public interface IPersonComparer
    {
        Task<ComparedPersons> Compare(IPerson person1, IPerson person2);
    }

    public record ComparedPersons(bool IsFullMatch);
}

