using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    internal class Reporter : Person
    {
        public string CodeName { get; set; }
        protected bool IsRecruited { get; set; } = false;
        protected int Rating { get; set; } = 0;

        


        // constructor
        public Reporter(string name, int id) : base(name, id)
        {
            this.CodeName = setCodeName();

        }


        // set new assigned to reporter
        public void setIsRecruise()
        {
            this.IsRecruited = Rating >= 10 ||  ;
        }


        // set code name to every new reporter
        public string setCodeName()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }






    }
}
