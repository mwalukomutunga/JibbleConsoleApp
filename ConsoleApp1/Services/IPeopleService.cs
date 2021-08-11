using JibbleConsoleClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JibbleConsoleClient.Services
{
    public interface IPeopleService
    {
        Task<List<Person>> ListPeople();
        Task<Person> PersonDetails(string username);
        Task<List<Person>> SearchPeople(string Keyword);
    }
}