using Malshinon.Data;
using Malshinon.Flow;

namespace Malshinon
{
    internal class Program
    {
        
        
        
        static void Main(string[] args)
        {
            Dal managereports = new Dal();

            Reporter reporter =new Reporter(58,"rerrr");
            Target target = new Target(96,"ali", 8);
            Report report = new Report();
            
            report.reporter = reporter;
            report.target = target;
            report.text = "תמיד שמח";
            
            managereports.AddReport(report);

        }
    }
}
