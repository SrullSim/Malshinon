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
        public int DangerLevel { get; set; } = 0;
        public int NumberOfReports { get; set; } = 0;


        public Target(string name, int dangerLevel): base(name)
        {
            this.CodeName = setCodeName();
            this.DangerLevel = dangerLevel;
        }



        // set code name to every new target
        public string setCodeName()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }

        // update number of reports
        public void setNumberOfReports()
        {
            this.NumberOfReports += 1 ;
        }




    }
}
