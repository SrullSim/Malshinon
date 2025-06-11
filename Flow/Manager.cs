using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Data;
namespace Malshinon.Flow
{
    internal class Manager
    {

        
        public static void start()
        {
            Dal dal = new Dal();
            int chois = Print.entryPrint();

            switch (chois)
            {
                case 1:
                    executeReport();

                    break;

                case 2:



                    break;



            }



        }





        public static void executeReport()
        {
            Dal dal = new Dal();
            Report report = new Report();

            // get reporter id
            report.reporter.Id = Print.Report_getReporterId();
            // gef reporter name
            report.reporter.Name = Print.Report_getReporterName();

            // get target  id
            report.target.Id = Print.ReportPrint_GetTargetId();
            // get target name
            report.target.Name = Print.Report_getTargetName();

            //get report text 
            report.text = Print.ReportPrint_GetText();

            dal.AddReport(report);
        }




    }
}
