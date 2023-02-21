using AutoMapper;
using myProject.Common;
using myProject.Repositories;
using myProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<DataDTO> AddPersonAsync(List<PersonDTO> p)
        {
           List<Person>person=new List<Person>();
            for (int i=0;i<p.Count;i++)
            {
                person.Add(_mapper.Map<Person>(p[i]));
            }
            DataDTO data =_mapper.Map<DataDTO>(await _personRepository.AddPersonAsync(person));
            return data;
        }
    }
}
