using Lesson07.Context;
using Lesson07.EFEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Lesson07.EFEntities.Task;

namespace Lesson07.Services
{
    public class ConnectionService
    {
        SqlConnectionStringBuilder builder { get; set; }
        SqlConnection connection { get; set; }

        public ConnectionService()
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-743MSBU";   // update me
            builder.UserID = "sonia";              // update me
            builder.Password = "36359637";      // update me
            builder.InitialCatalog = "Lesson07";

            connection = new SqlConnection(builder.ConnectionString);
        }

        public SqlConnectionStringBuilder GetBuilder()
        {
            return builder;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void Connect(SqlConnection connection)
        {
            try
            {
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                connection.Open();
                Console.WriteLine("Done.");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Press any key to finish...");
            Console.ReadKey(true);
        }

        public void CreateDB(SqlConnection connection)
        {
            try
            {
                // Create a sample database
                Console.Write("Dropping and creating database 'SampleDB' ... ");
                String sql = "DROP DATABASE IF EXISTS [SampleDB]; CREATE DATABASE [SampleDB]";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

                // Create a Table and insert some sample data
                Console.Write("Creating sample table with data, press any key to continue...");
                Console.ReadKey(true);
                StringBuilder sb = new StringBuilder();
                sb.Append("USE SampleDB; ");
                sb.Append("CREATE TABLE Employees ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                sb.Append(" Name NVARCHAR(50), ");
                sb.Append(" Location NVARCHAR(50) ");
                sb.Append("); ");
                sb.Append("INSERT INTO Employees (Name, Location) VALUES ");
                sb.Append("(N'Jared', N'Australia'), ");
                sb.Append("(N'Nikita', N'India'), ");
                sb.Append("(N'Tom', N'Germany'); ");
                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

                // READ demo
                Console.WriteLine("Reading data from table, press any key to continue...");
                Console.ReadKey(true);
                sql = "SELECT Id, Name, Location FROM Employees;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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

        public void CreateEFDemo(SqlConnectionStringBuilder builder)
        {
            try
            {
                using (EFContext context = new EFContext(builder.ConnectionString))
                {
                    Console.WriteLine("Created database schema from C# classes.");

                    // Create demo: Create a User instance and save it to the database
                    User newUser = new User { FirstName = "Anna", LastName = "Shrestinian" };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated User: " + newUser.ToString());

                    // Create demo: Create a Task instance and save it to the database
                    Task newTask = new Task() { Title = "Ship Helsinki", IsComplete = false, DueDate = DateTime.Parse("01-04-2017") };
                    context.Tasks.Add(newTask);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated Task: " + newTask.ToString());

                    // Association demo: Assign task to user
                    newTask.AssignedTo = newUser;
                    context.SaveChanges();
                    Console.WriteLine("\nAssigned Task: '" + newTask.Title + "' to user '" + newUser.GetFullName() + "'");

                    // Read demo: find incomplete tasks assigned to user 'Anna'
                    Console.WriteLine("\nIncomplete tasks assigned to 'Anna':");
                    var query = from t in context.Tasks
                                where t.IsComplete == false &&
                                t.AssignedTo.FirstName.Equals("Anna")
                                select t;
                    foreach (var t in query)
                    {
                        Console.WriteLine(t.ToString());
                    }

                    // Update demo: change the 'dueDate' of a task
                    Task taskToUpdate = context.Tasks.First(); // get the first task
                    Console.WriteLine("\nUpdating task: " + taskToUpdate.ToString());
                    taskToUpdate.DueDate = DateTime.Parse("30-06-2016");
                    context.SaveChanges();
                    Console.WriteLine("dueDate changed: " + taskToUpdate.ToString());

                    // Delete demo: delete all tasks with a dueDate in 2016
                    Console.WriteLine("\nDeleting all tasks with a dueDate in 2016");
                    DateTime dueDate2016 = DateTime.Parse("31-12-2016");
                    query = from t in context.Tasks
                            where t.DueDate < dueDate2016
                            select t;
                    foreach (Task t in query)
                    {
                        Console.WriteLine("Deleting task: " + t.ToString());
                        context.Tasks.Remove(t);
                    }
                    context.SaveChanges();

                    // Show tasks after the 'Delete' operation - there should be 0 tasks
                    Console.WriteLine("\nTasks after delete:");
                    List<Task> tasksAfterDelete = (from t in context.Tasks select t).ToList<Task>();
                    if (tasksAfterDelete.Count == 0)
                    {
                        Console.WriteLine("[None]");
                    }
                    else
                    {
                        foreach (Task t in query)
                        {
                            Console.WriteLine(t.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);
        }

        public void CreateIndex(SqlConnection connection)
        {
            try
            {
                // Create a sample database
                Console.Write("Dropping and creating database 'IndexDB' ... ");
                String sql = "DROP DATABASE IF EXISTS [IndexDB]; CREATE DATABASE [IndexDB]";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();

                    Console.WriteLine("Done.");
                }

                // Insert 5 million rows into the table 'Table_with_5M_rows'
                Console.Write("Inserting 5 million rows into table 'Table_with_5M_rows'. This takes ~1 minute, please wait ... ");
                StringBuilder sb = new StringBuilder();
                sb.Append("USE IndexDB; ");
                sb.Append("WITH a AS (SELECT * FROM (VALUES(1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS a(a))");
                sb.Append("SELECT TOP(5000000)");
                sb.Append("ROW_NUMBER() OVER (ORDER BY a.a) AS OrderItemId ");
                sb.Append(",a.a + b.a + c.a + d.a + e.a + f.a + g.a + h.a AS OrderId ");
                sb.Append(",a.a * 10 AS Price ");
                sb.Append(",CONCAT(a.a, N' ', b.a, N' ', c.a, N' ', d.a, N' ', e.a, N' ', f.a, N' ', g.a, N' ', h.a) AS ProductName ");
                sb.Append("INTO Table_with_5M_rows ");
                sb.Append("FROM a, a AS b, a AS c, a AS d, a AS e, a AS f, a AS g, a AS h;");
                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

                // Execute SQL query without columnstore index
                double elapsedTimeWithoutIndex = SumPrice(connection);
                Console.WriteLine("Query time WITHOUT columnstore index: " + elapsedTimeWithoutIndex + "ms");

                // Add a Columnstore Index
                Console.Write("Adding a columnstore to table 'Table_with_5M_rows'  ... ");
                sql = "CREATE CLUSTERED COLUMNSTORE INDEX columnstoreindex ON Table_with_5M_rows;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

                // Execute the same SQL query again after columnstore index was added
                double elapsedTimeWithIndex = SumPrice(connection);
                Console.WriteLine("Query time WITH columnstore index: " + elapsedTimeWithIndex + "ms");

                // Calculate performance gain from adding columnstore index
                Console.WriteLine("Performance improvement with columnstore index: "
                    + Math.Round(elapsedTimeWithoutIndex / elapsedTimeWithIndex) + "x!");

                Console.WriteLine("All done. Press any key to finish...");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        double SumPrice(SqlConnection connection)
        {
            String sql = "SELECT SUM(Price) FROM Table_with_5M_rows";
            long startTicks = DateTime.Now.Ticks;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                try
                {
                    var sum = command.ExecuteScalar();
                    TimeSpan elapsed = TimeSpan.FromTicks(DateTime.Now.Ticks) - TimeSpan.FromTicks(startTicks);
                    return elapsed.TotalMilliseconds;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return 0;
        }
    }
}
