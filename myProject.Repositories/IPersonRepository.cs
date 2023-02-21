using myProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Repositories
{
    public interface IPersonRepository
    {
        public Task<Data> AddPersonAsync(List<Person>p);

    }
}
