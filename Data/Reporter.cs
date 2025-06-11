using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    internal class Reporter : Person
    {
        public string codeName { get; set; }
        protected bool IsRecruited { get; set; } = false;
        public int rating { get; set; } = 0;

        


        // constructor
        public Reporter(string name) : base(name)
        {
            this.codeName = setCodeName();

        }


        // set new assigned to reporter
        public bool setIsRecruise()
        {
            return this.IsRecruited = rating >= 10  ;
        }


        // set code name to every new reporter
        public string setCodeName()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }

        // update rating
        public void setRating()
        {
            this.rating += 1 ;
        }



    }
}
