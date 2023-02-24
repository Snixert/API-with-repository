using Friday.Repository.Models;

namespace Friday.Repository.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id);
        Task<List<Person>> GetPersons();
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<string> DeletePerson(int id);
    }
}
