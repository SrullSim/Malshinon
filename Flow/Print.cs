using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Flow
{
    internal static class Print
    {

        // all the prints will be here

        public static int entryPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to Malshinon, the secret organization for world domination");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Report");
            Console.WriteLine("2. Management login");
            Console.WriteLine("3. Exit ");
            Console.WriteLine("Your choice -    ");
            int coise = int.Parse(Console.ReadLine());
            return coise;
        }


        public static int Report_getReporterId()
        { 
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the report menu");
            Console.WriteLine("Please enter your id : ");
            int choise = int.Parse(Console.ReadLine());
            return choise;
        }


        public static string Report_getReporterName()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the report menu");
            Console.WriteLine("Please enter your name : ");
            string choise = Console.ReadLine();
            return choise;

        }
        public static int ReportPrint_GetTargetId()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Please enter your target id \n  ");
            int choise = int.Parse(Console.ReadLine());
            return choise;

        }


        public static string Report_getTargetName()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the report menu");
            Console.WriteLine("Please enter your target name : ");
            string choise = Console.ReadLine();
            return choise;
        }

        public static string ReportPrint_GetText()
        {
            Console.WriteLine("enter your report  \n  ");
            string choise = Console.ReadLine();
            return choise;
        }


        public static void reportSuccessPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Your report has been successfully sent to our system ");
            Console.WriteLine("Thank you for your service to Malshinon");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void managementLoginPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the management login");
            Console.WriteLine("Please enter your name Code name:  \n  ");
        }


        public static void managementPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the management menu");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add Agent");
            Console.WriteLine("2. View Agents");
            Console.WriteLine("3. View Targets");
            Console.WriteLine("4. View Reporters");
            Console.WriteLine("5. View Reports");
            Console.WriteLine("6. Exit");
            Console.WriteLine("   Your choice: \n  ");

        }


        public static void agentAddedPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Agent has been successfully added to the system");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void agentExistsPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Agent already exists in the system");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void agentNotFoundPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Agent not found in the system");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void targetNotFoundPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Target not found in the system");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void reporterNotFoundPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Reporter not found in the system");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }











    }
}
