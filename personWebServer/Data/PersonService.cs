using System;
using System.Linq;
using System.Threading.Tasks;

namespace personWebServer.Data
{
    public class PeopleService
    {
        private static readonly String[] FirstNames = new[]
        {
            "Dave", "Phil", "Andy", "Todd", "Ronald"
        };
        
        private static readonly String[] LastNames = new[]
        {
            "Zhong", "Rasmussen", "Scott", "Pedersen", "Johnson"
        };
        
        public Task<Person[]> GetPeopleAsync()
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Person
            {
                FirstName = FirstNames[rng.Next(FirstNames.Length)],
                LastName = LastNames[rng.Next(LastNames.Length)],
                personId = rng.Next(0, 100)
            }).ToArray());
        }
    }
}