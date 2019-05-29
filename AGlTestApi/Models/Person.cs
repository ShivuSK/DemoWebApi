using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGLTestApi.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pets> Pets { get; set; }
    }
}
