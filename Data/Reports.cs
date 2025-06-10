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
    internal class Reports
    {
        Queries Queries = new();
        protected List<string> Names = new();
        protected string connectionString { get; set; } = "server=localhost;"+
                                                          "port=3306;" +
                                                          "user=root;" +
                                                          "password=;" +
                                                          "database=malshinon;";

        MySqlConnection connect = new MySqlConnection();

        public string AddReport(Report report)
        {

            connect.ConnectionString = connectionString;    

            if (!Names.Contains(report.reporter.Name))
            {

                try
                {
                    connect.Open();
                    string query = @"INSERT INTO reports(reporter, target, text, timeOfReport) 
                                   VALUE(@reporter, @target, @text, @timeOfReport)";

                    MySqlCommand command = new MySqlCommand(query, connect);

                    command.Parameters.AddWithValue("@reporter", report.reporter.CodeName);
                    command.Parameters.AddWithValue("@target", report.target.Name);
                    command.Parameters.AddWithValue("@text", report.text);
                    command.Parameters.AddWithValue("@timeOfReport", report.timeOfReport);

                    int result = command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return "Error: " + ex.Message;
                }
            }
            return "";
        }


        public Agent GetAgent(int id)
        {
            // create object
            Agent agent = new Agent();

            // create connection
            connect.ConnectionString = connectionString;

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























        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            MySqlConnection connection = new MySqlConnection(connectionString);






            return reports;
        }

    }
}
