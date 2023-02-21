using myProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace myProject.Repositories
{
    public class PersonRepository : IPersonRepository
    {
     
        public async Task<Data> AddPersonAsync(List<Person> p)
        {
            Data data = new Data();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sq.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync( "/People", p);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            data.PeopleFromAPI = JsonSerializer.Deserialize<List<PersonWithId>>(result);
            foreach (var item in p)
            {
                //check validation of tz
                if (item.tz.Length < 9)
                    data.InvalidPeople.Add(item);
            }
            return data;

        }
    }
}
