using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace personWebServer.Data
{
    public class PersonService
    {
        private static readonly String[] FirstNames = new[]
        {
            "Dave", "Phil", "Andy", "Todd", "Ronald", "Scott", "Daniel", "Marcus"
        };
        
        private static readonly String[] LastNames = new[]
        {
            "Zhong", "Rasmussen", "Scott", "Pedersen", "Johnson", "Laney", "Park", "Andersen"
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

        public void PostPerson()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 4265; Database=people");
            conn.Open();
            Console.WriteLine("Connected");
            
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO people.people VALUES ('Ronald', 'Johnson')", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void GetPeople()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 4265; Database=people");
        }
    }
}