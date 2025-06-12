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
    internal class Dal
    {
        protected List<string> Names = new();

        // the connection string
        public static string connectionString { get; set; } = "server=localhost;" +
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

                connect.Close();


                // add the reporter to DB reporters
                AddReporterToDB(report.reporter);

                // add the target to DB targets
                AddTargetToDB(report.target);


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
            if (!IsIdExists("reporters", reporter.Id))
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
                    Console.WriteLine($"faild reporetr {ex.Message}");
                    return "error: " + ex.Message;
                }
                finally { connect.Close(); }
            }
            else
            {
                updateReporter(reporter);
                return "the reporter update successfully";
            }
        }


        // add target to DB targets
        public string AddTargetToDB(Target target)
        {
            string query = Queries.insertTarget;

            if (!IsIdExists("targets", target.Id))
            {
                try
                {
                    connect.Open();

                    // set query
                    MySqlCommand command = new MySqlCommand(query, connect);

                    command.Parameters.AddWithValue("@id", target.Id);
                    command.Parameters.AddWithValue("@name", target.Name);
                    command.Parameters.AddWithValue("@codeName", target.codeName);
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
            else
            {
                Console.WriteLine("is exsist");
                string done = updateTargetsById(target);
                return done;
            }
        }

        // get agent by id
        public Agent GetAgentById(int id)
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

                if (reader.Read())
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
                return null;
            }
            finally { connect.Close(); }


        }

        // egt target by id
        public Agent GetTargetById(int id)
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


        public static bool IsIdExists(string tableName, int id)
        {
            // check for sql injection
            if (string.IsNullOrWhiteSpace(tableName) || tableName.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException("Invalid table name");

            //set query
            string query = $"SELECT EXISTS (SELECT 1 FROM {tableName} WHERE id=@id)";

            // connection
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                try
                {
                    //start connection
                    connect.Open();

                    // commander
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@id", id);

                    // execute the query
                    object result = command.ExecuteScalar();

                    return Convert.ToInt32(result) == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                    return false;
                }
                finally { connect.Close(); }
            }
        }


        public string updateTargetsById(Target target)
        {
            //set query
            string query = Queries.updateTargetsById;

            using (MySqlCommand command = new MySqlCommand(query, connect))

                try
                {
                    connect.Open();

                    command.Parameters.AddWithValue("@numberOfReports", getNumberOfReports(target) + 1);
                    command.Parameters.AddWithValue("@name", target.Id);

                    // execute 
                    command.ExecuteNonQuery();
                    Console.WriteLine("33333333333333333");
                    return "update target numberOfReports";

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                    return "error: " + ex.Message;
                }
                finally { connect.Close(); }
        }


        public string updateReporter(Reporter reporter)
        {
            string query = Queries.updateReporter;

            using (MySqlCommand command = new MySqlCommand(query, connect))

                try
                {
                    connect.Open();

                    command.Parameters.AddWithValue("@rating", getRating(reporter) + 1);
                    command.Parameters.AddWithValue("@id", reporter.Id);

                    // execute
                    command.ExecuteNonQuery();
                    Console.WriteLine("rating = updateReporter() " + reporter.rating);
                    return "the reporter update successfully";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                    return "error: " + ex.Message;
                }
                finally { connect?.Close(); }


        }


        // check for reporter code name
        public static string getReportrterCodeNameById(int id)
        {
            string query = Queries.getReporterCodeNameById;

            MySqlConnection connect = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, connect))

                try
                {
                    connect.Open();

                    command.Parameters.AddWithValue("@id", id);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        Console.WriteLine("no code name provide");
                        return "code name not found";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("error get codeName: " + ex.Message);
                    return "error to get code name :" + ex.Message;
                }
                finally { connect?.Close(); }
        }


        // check for target code anme
        public static string getTargetCodeNameById(int id)
        {
            if (!IsIdExists("targets", id))
            {


                string query = Queries.getReporterCodeNameById;

                MySqlConnection connect = new MySqlConnection(connectionString);

                using (MySqlCommand command = new MySqlCommand(query, connect))

                    try
                    {
                        connect.Open();

                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            Console.WriteLine(id + " ppppooooodidiididid target get");

                            return result.ToString();
                        }
                        else
                        {
                            Console.WriteLine("no code name provide target ");
                            return "code name not found";
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("error get codeName: " + ex.Message);
                        return "error to get code name :" + ex.Message;
                    }
                    finally { connect?.Close(); }
            }
            else
            {
                return "rrrrr";
            }
        }





        public static int getRating(Reporter reporter)
        {
            if (reporter != null)
            {
                string query = Queries.getRatingReporter;

                MySqlConnection connect = new MySqlConnection(connectionString);

                try
                {
                    connect.Open();
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@id", reporter.Id);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        reporter.rating = Convert.ToInt32(result);
                        Console.WriteLine("rating = getRating () " + reporter.rating);
                        return reporter.rating;

                    }
                    else
                    {
                        Console.WriteLine("no rating found for this reporter");
                        reporter.rating = 0; // default rating if not found
                        return reporter.rating;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("error get rating: " + ex.Message);
                    return -1;
                }
                finally
                {
                    connect?.Close();
                }
            }
            else
            {
                return -1; 
            }

        }



        public static int getNumberOfReports(Target target)
        {
            if (target != null)
            {
                string query = Queries.getNumberOfReports;

                MySqlConnection connect = new MySqlConnection(connectionString);

                try
                {
                    connect.Open();
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@id", target.Id);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        target.NumberOfReports = Convert.ToInt32(result);
                        Console.WriteLine("rating = " + target.NumberOfReports);
                        return target.NumberOfReports;

                    }
                    else
                    {
                        Console.WriteLine("no rating found for this reporter");
                        target.NumberOfReports = 0; // default rating if not found
                        return target.NumberOfReports;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("error get rating: " + ex.Message);
                    return -1;
                }
                finally
                {
                    connect?.Close();
                }
            }
            else
            {
                return -1;
            }

        }














    }
}
