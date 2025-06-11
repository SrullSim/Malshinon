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


        public Target(int id ,string name, int dangerLevel): base(id, name)
        {
            this.Id = id;
            this.CodeName = setCodeName(id);
            this.DangerLevel = dangerLevel;

        }



        // set code name to every new target
        public static string setCodeName(int id)
        {
            if (Dal.IsIdExists("reporters", id))
            {
                return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            }
            else
            {
                return Dal.getTargetCodeNameById(id);
            }
        }

        // update number of reports
        public void setNumberOfReports()
        {
            this.NumberOfReports += 1 ;
        }




    }
}
