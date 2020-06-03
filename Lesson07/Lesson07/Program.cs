using Lesson07.Context;
using Lesson07.EFEntities;
using Lesson07.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task = Lesson07.EFEntities.Task;

namespace Lesson07
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            ConnectionService connectionService = new ConnectionService();

            do
            {
                Console.WriteLine("Choose an option\n" 
                                    + "1. Ado Connect Server Demo\n" //First step on walk through simply connect to server
                                    + "2. Ado Create Database Demo\n" //Creates a DB using Classic ADO.Net and adds records to a table
                                    + "3. EF Crud Demo\n" //Creates a DB, and executes crud operations over tables using Entity Framework
                                    + "4. Index Demo\n" //Optimizes queries to a table using index
                                    + "5. Exit");
                option = Convert.ToInt32(Console.ReadLine());

                if (option != 5)
                {
                    switch (option)
                    {
                        case 1:
                            {
                                connectionService.Connect(connectionService.GetConnection());
                                break;
                            }
                        case 2:
                            {
                                connectionService.CreateDB(connectionService.GetConnection());
                                break;
                            }
                        case 3:
                            {
                                connectionService.CreateEFDemo(connectionService.GetBuilder());
                                break;
                            }
                        case 4:
                            {
                                connectionService.CreateIndex(connectionService.GetConnection());
                                break;
                            }
                    }
                    Console.WriteLine("\n---------------------------------\n");
                }

            } while (option != 5);

            Console.ReadKey(true);
        }        
    }    
}
