using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Common
{
    public class PersonWithIdDTO
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public int yearOfBirth { get; set; }
        public string tz { get; set; }
    }
}
