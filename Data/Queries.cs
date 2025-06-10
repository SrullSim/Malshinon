using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    internal  class Queries
    {

        // querrys from table agents

        public static string insertAgent = @"INSERT INTO alerts(id, name, codeName, rank) VALUE(@id, @name, @codename, @arank)";

        public static string getAgent = @"SELECT * FROM alerts WHERE id=@id";



        // querys from table reports
        public string insertReport = @"INSERT INTO reports(id, reporter, target, text, timeOfReport) VALUE(@id, @reporter,@target, @text, @timeOfReport)";

        public string getReport = @"SELECT * FROM reports WHERE id=@id";

       


        // querys from table reporters
        public static string insertReporter = @"INSERT INTO reporters(id, name, codeName, rating, status) VALUE(@id, @name, @codeName, @rating, @status";

        public static string getReporter = @"SELECT * FROM reporters WHERE id=@iD OR name=@name OR codeName=@codeName";
        


        // querrys from table targets
        public static string insertTarget = @"INSERT INTO targets(id, codeName, dangerous) VALUE(@id, @codeName, @dangerous)";

        public string getTarget = @"SELECT * FROM reporters WHERE id=@id OR codeName=@codeName";



        // querrys from table alerts
        public static string insertAlert = @"INSERT INTO alerts(id, target, time, description) VALUE(@id, @target, @time, @description)";

        public string getAlert = @"SELECT * FROM alerts WHERE id=@id";
        


        






    }
}
