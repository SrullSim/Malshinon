using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Flow
{
    internal class Print
    {

        // all the prints will be here

        public static void entryPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to Malshinon, the secret organization for world domination");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Report");
            Console.WriteLine("2. Management login");
            Console.WriteLine("3. Exit ");
            Console.WriteLine("4. Your choice: \n  ");
        }


        public static void Report()
        { 
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Welcome to the report menu");
            Console.WriteLine("Please enter your name or Code name : ");
            Console.WriteLine("0.Back to main menu");
        }


        public static void ReportPrint()
        {
            Console.Clear();
            Console.WriteLine("===============    Malshinon    ===============");
            Console.WriteLine("Please enter your target \n  ");
            Console.WriteLine("enter your report  \n  ");
            Console.WriteLine("0.Back to main menu");
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
