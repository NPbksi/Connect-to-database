using System;
using System.Text;
using System.Data.SqlClient;

namespace Taty
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Build connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   // update me
            builder.UserID = "sa";              // update me
            builder.Password = "nadya";      // update me
            builder.InitialCatalog = "Students";

            // Connect to SQL
            Console.Write("Connecting to SQL Server ... ");
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done.");

                // Create a sample database
                String sql = "Students";
                using (SqlCommand command = new SqlCommand(sql, connection))
           //Name.......
                    Console.WriteLine("Find Name ");
                    //Console.WriteLine(Console.ReadLine());
                    string @name1 = Console.ReadLine();
                string name1 = @name1;
                // READ Filter
                Console.ReadKey(true);
                sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info WHERE Name Like @name1;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (
                        SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetString(4));
                        }
                    }
                }
                if (string.IsNullOrEmpty(name1))
                {
                    try
                    {
                                // READ demo
                                Console.WriteLine("Reading data from table, press any key to continue...");
                            Console.ReadKey(true);
                            sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info;";
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetString(4));
                                    }
                                }
                            }
                        
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
              //Age......
                    Console.WriteLine("Find Age ");
                    //Console.WriteLine(Console.ReadLine());
                    string age1 = Console.ReadLine();

                    // READ Filter
                    Console.ReadKey(true);
                    sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info WHERE Age Like @age1;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (
                            SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetString(4));
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(name1))
                    {
                        try
                        {
                            // READ demo
                            Console.WriteLine("Reading data from table, press any key to continue...");
                            Console.ReadKey(true);
                            sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info;";
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetString(4));
                                    }
                                }
                            }
                        }


                        catch (SqlException e)
                        {
                            Console.WriteLine(e.ToString());
                        }


                        Console.WriteLine("All done. Press any key to finish...");
                        Console.ReadKey(true);
                    }
                }
            }
        }
    }
}



