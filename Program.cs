using Malshinon.Data;
using Malshinon.Flow;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManageReports managereports = new ManageReports();

            Reporter reporter =new Reporter("נסיוני");
            Target target = new Target("חיובי",4);
            Report report = new Report();
            
            report.reporter = reporter;
            report.target = target;
            report.text = "תמיד שמח";
            
            managereports.AddReport(report);
            Agent p = managereports.GetTarget(12);
            Console.WriteLine(p.codeName);
        }
    }
}
