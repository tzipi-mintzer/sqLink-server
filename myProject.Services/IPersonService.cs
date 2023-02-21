using myProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services
{
    public interface IPersonService
    {
        Task<DataDTO> AddPersonAsync(List<PersonDTO> p);
    }
}
