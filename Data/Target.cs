using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    internal class Target: Person
    {

        public string CodeName {  get; set; }
        protected int DangerLevel { get; set; } = 0;


        public Target(string name, int id, int dangerLevel): base(name, id)
        {
            this.CodeName = setCodeName();
            this.DangerLevel = dangerLevel;
        }



        // set code name to every new target
        public string setCodeName()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }




    }
}
