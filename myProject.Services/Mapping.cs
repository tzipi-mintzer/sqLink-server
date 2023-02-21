using AutoMapper;
using myProject.Common;
using myProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Person, PersonDTO>()
             .ReverseMap();
            CreateMap<Data, DataDTO>()
        .ReverseMap();
        }
    }
}
