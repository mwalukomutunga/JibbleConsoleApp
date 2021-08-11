using JibbleConsoleClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JibbleConsoleClient.Services
{
    public class PeopleService : IPeopleService
    {
        //ListPeople_ShouldLoadPeople
        public async Task<List<Person>> ListPeople()
        {
            var url = "https://services.odata.org/TripPinRESTierService/People";
            var results = await HttpHelper.ProcessGetRequest<People>(AppConstant.Header, url);
            return results.Value;
        }
        public async Task<List<Person>> SearchPeople(string Keyword)
        {
            var url = $"https://services.odata.org/TripPinRESTierService/People?$search='{Keyword}'";
            var results = await HttpHelper.ProcessGetRequest<People>(AppConstant.Header, url);
            return results.Value;
        }
        public async Task<Person> PersonDetails(string username)
        {
            var url = $"https://services.odata.org/TripPinRESTierService/People('{username}')";
            return await HttpHelper.ProcessGetRequest<Person>(AppConstant.Header, url);
        }
       
    }
}
