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
        public Reporter(int id,string name) :  base(id , name)
        {
            this.codeName = setCodeName(id);

        }

        public Reporter() { }


        // set new assigned to reporter
        public bool setIsRecruise()
        {
            return this.IsRecruited = rating >= 10  ;
        }


        // set code name to every new reporter
        public static string setCodeName(int id)
        {
            if (Dal.IsIdExists("reporters", id))
            {
                return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            }
            else
            {
                return Dal.getReportrterCodeNameById(id);
            }
        }

        // update rating
        public void setRating()
        {
            this.rating += 1 ;
        }

        public void setID(int id)
        {
            this.Id = id ;
        }

        public void setName(string name)
        {
            this.Name = name ;
        }

    }
}
