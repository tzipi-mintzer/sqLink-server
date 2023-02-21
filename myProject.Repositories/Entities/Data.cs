using myProject.Repositories.Entities;

namespace myProject.Repositories.Entities
{
    public class Data
    {
        public List<PersonWithId> PeopleFromAPI { get; set; }
        public List<Person> InvalidPeople { get; set; }
        public Data()
        {
            PeopleFromAPI = new List<PersonWithId>();
            InvalidPeople = new List<Person>();
        }
    }
}
