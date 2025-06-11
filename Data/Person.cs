using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    abstract class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        
        public Person(int id,string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public Person() { }






    }
}
