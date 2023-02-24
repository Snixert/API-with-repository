using Friday.Repository.Data;
using Friday.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friday.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext context;

        public PersonRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<Person>> GetPersons()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person is null)
            {
                return null;
            }
            return person;
        }

        public async Task<Person> AddPerson(Person person)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();

            return person;
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var p = await context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);

            if (p is null)
            {
                return null;
            }
            p.Name = person.Name;
            p.Age = person.Age;
            p.Cars = person.Cars;

            context.Entry(p).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return p;
        }

        public async Task<string> DeletePerson(int id)
        {
            var person = await context.Persons.FindAsync(id);
            if (person is null)
            {
                return $"Unable to find car with id = {id}";
            }

            context.Persons.Remove(person);
            await context.SaveChangesAsync();
            return $"Deleted car with id = {id}";
        }
    }
}
