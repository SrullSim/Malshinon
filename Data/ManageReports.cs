using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Flow;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MySql.Data.MySqlClient;
using static Malshinon.Data.Queries;


namespace Malshinon.Data
{
    internal class ManageReports
    {
        protected List<string> Names = new();

        // the connection string
        public static string connectionString { get; set; } = "server=localhost;"+
                                                          "port=3306;" +
                                                          "user=root;" +
                                                          "password=;" +
                                                          "database=malshinon;";
        // create connction
        MySqlConnection connect = new MySqlConnection(connectionString);


        // add report to DB
        public string AddReport(Report report)
        {
            try
            {
                // open connection
                connect.Open();
                
                //string query = Queries.insertReport;
                string query = @"INSERT INTO reports(reporter, target, text, timeOfReport) 
                                   VALUE(@reporter, @target, @text, @timeOfReport)";

                MySqlCommand command = new MySqlCommand(query, connect);

                command.Parameters.AddWithValue("@reporter", report.reporter.Name);
                command.Parameters.AddWithValue("@target", report.target.Name);
                command.Parameters.AddWithValue("@text", report.text);
                command.Parameters.AddWithValue("@timeOfReport", report.timeOfReport);

                int result = command.ExecuteNonQuery();
                Console.WriteLine("succcessfully" );

                connect.Close();

                // add the reporter to DB reporters
                AddReporterToDB(report.reporter);
                report.reporter.setRating();
                Console.WriteLine("db reporter");

                // add the target to DB targets
                AddTargetToDB(report.target);
                report.target.setNumberOfReports();


                return "report added successfully";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return "Error: " + ex.Message;
            }
            finally 
            {
                // closing the connection
                connect.Close();
                report.target.DangerLevel += 1;
            }

        }
        

        // add reporter to DB reporters
        public string AddReporterToDB(Reporter reporter)
        {
            try
            {
                connect.Open();

                // set query
                string query = Queries.insertReporter;

                MySqlCommand command = new MySqlCommand(query, connect);


                command.Parameters.AddWithValue("@id", reporter.Id);
                command.Parameters.AddWithValue("@name", reporter.Name);
                command.Parameters.AddWithValue("@codeName", reporter.codeName);
                command.Parameters.AddWithValue("@rating", reporter.rating);


                // execute the commad
                command.ExecuteNonQuery();

                return " reporter add successfully to reporters";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"faild {ex.Message}");
                return "error: " + ex.Message;
            }
            finally { connect.Close(); }
        }


        // add target to DB targets
        public string AddTargetToDB(Target target)
        {
            string query = Queries.insertTarget;
            try
            {
                connect.Open();

                // set query
                MySqlCommand command = new MySqlCommand(query,connect); 

                command.Parameters.AddWithValue("@name", target.Name);
                command.Parameters.AddWithValue("@codeName",target.CodeName);
                command.Parameters.AddWithValue("@dangerous", target.DangerLevel);
                command.Parameters.AddWithValue("@numberOfReports", target.NumberOfReports);

                // execute the query & close
                command.ExecuteNonQuery();

                return "target add successfully";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return "error: " + ex.Message;
            }
            finally 
            { connect.Close(); }
        }




























        public Agent GetAgent(int id)
        {
            // create object
            Agent agent = new Agent();


            // create query
            string query = Queries.getAgent;

            try
            {
                // active the connection
                connect.Open();

                // create commnd 
                MySqlCommand command = new MySqlCommand(query, connect);

                command.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    agent.id = reader.GetInt32("id");
                    agent.name = reader.GetString("name");
                    agent.codeName = reader.GetString("codeName");
                }
                return agent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error {ex.Message}");
                connect.Close();
                return null;
            }

        }



        public Agent GetTarget(int id)
        {
            // create object
            Agent agent = new Agent();


            // create query
            string query = Queries.getTarget;

            try
            {
                // active the connection
                connect.Open();

                // create commnd 
                MySqlCommand command = new MySqlCommand(query, connect);

                command.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    agent.id = reader.GetInt32("id");
                    agent.name = reader.GetString("name");
                    agent.codeName = reader.GetString("codeName");
                    Console.WriteLine("wwwwwwwwwwwwwww");

                }
                return agent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error {ex.Message}");
                return null;
            }
            finally { connect.Close(); }
        }










        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            MySqlConnection connection = new MySqlConnection(connectionString);






            return reports;
        }

    }
}
