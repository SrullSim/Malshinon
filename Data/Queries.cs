using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.Collections;
using System.Xml.Linq;

namespace Malshinon.Data
{
    internal  class Queries
    {

        // querrys from table agents

        public static string insertAgent = @"INSERT INTO agents(id, name, codeName, rank) VALUE(@id, @name, @codename, @arank)";

        public static string getAgent = @"SELECT * FROM agents WHERE id=@id";



        // querys from table reports
        public static string insertReport = @"INSERT INTO reports(reporter, target, text, timeOfReport) VALUE(@reporter,@target, @text, @timeOfReport)";
        
        public static string getReport = @"SELECT * FROM reports WHERE id=@id";

        public static string deleteReport = "DELETE ";




        // querys from table reporters
        public static string insertReporter = @"INSERT INTO reporters(id, name, codeName, rating) VALUES(@id, @name, @codeName, @rating)";
        
        public static string getReporter = @"SELECT * FROM reporters WHERE id=@iD OR name=@name OR codeName=@codeName";
        
        public static string updateReporter = @"UPDATE reporters SET rating=@rating WHERE id=@id";


        // querrys from table targets
        public static string insertTarget = @"INSERT INTO targets(id, name, codeName, dangerous) VALUE(@id, @name, @codeName, @dangerous)";

        public static string getTarget = @"SELECT * FROM targets WHERE id=@id";

        public static string updateTargetsById = @"UPDATE targets SET numberOfReports=@numberOfReports  WHERE id=@id";



        // querrys from table alerts
        public static string insertAlert = @"INSERT INTO alerts(id, target, time, description) VALUE(@id, @target, @time, @description)";

        public static string getAlert = @"SELECT * FROM alerts WHERE id=@id";


        public static string getReporterCodeNameById = "SELECT codeName FROM reporters WHERE id=@id";
        
        public static string getTargetCodeNameById = "SELECT codeName FROM targets WHERE id=@id";

        public static string getRatingReporter = "SELECT rating FROM reporters WHERE id=@id";
        
        public static string getNumberOfReports = "SELECT numberOfReports FROM targets WHERE id=@id";







    }
}
