using myProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Common
{
    public class DataDTO
    {
        public List<PersonWithId> PeopleFromAPI { get; set; }
        public List<Person> InvalidPeople { get; set; }
    }
}
