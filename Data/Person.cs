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
        protected int Id { get; set; }

        
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }






    }
}
