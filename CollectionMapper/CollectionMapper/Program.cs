using CollectionMapper.Entities;
using CollectionMapper.ExtensionMethods;
using Globant.Java2Net.Demos.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionMapper
{
    class Program
    {
        static int option = 0;

        static void Main(string[] args)
        {            
            JsonFileReader<Student> fileReader = new JsonFileReader<Student>();

            do
            {
                Console.WriteLine("Choose an option:\n1. CollectionMapper\n2. Linq and Events\n3. Exit");
                option = Convert.ToInt32(Console.ReadLine());

                if (option != 3)
                {
                    if (option == 1)
                    {
                        fileReader.OnFileRead += MapperHandler;

                        fileReader.ReadJsonFile(@"JsonFiles\Students.json");

                        fileReader.OnFileRead -= MapperHandler;
                    }
                    if (option == 2)
                    {
                        fileReader.OnFileRead += CountHandler;
                        fileReader.OnFileRead += ClassHandler;
                        fileReader.OnFileRead += SocialHandler;
                        fileReader.OnFileRead += LockerHandler;

                        fileReader.ReadJsonFile(@"JsonFiles\Students.json");

                        fileReader.OnFileRead -= CountHandler;
                        fileReader.OnFileRead -= ClassHandler;
                        fileReader.OnFileRead -= SocialHandler;
                        fileReader.OnFileRead -= LockerHandler;
                    }
                    
                    Console.WriteLine("---------------------------------------------------------------\n");
                }
            } while (option != 3);

            Console.ReadKey();
        }

        static Action<IList<Student>> MapperHandler = students =>
        {
            Console.WriteLine("students size {0}", students.Count());
            foreach (Student student in students)
            {
                Console.WriteLine("Student name: {0}", student.Name);
            }
            IEnumerable<Person> people = students.MapCollection<Student, Person>(x => new Person() { Name = x.Name });
            Console.WriteLine("people size {0}", people.Count());
            foreach (Person person in people)
            {
                Console.WriteLine("Person name: {0}", person.Name);
            }
        };

        static Action<IList<Student>> CountHandler = students => Console.WriteLine("\nExecuting Filter Elements count \nstudents collection size {0}", students.Count());

        static Action<IList<Student>> ClassHandler = students =>
        {
            Console.WriteLine("\nExecuting Filter Class 12");
            List<Student> class12 = students.Where(x => x.Class == "12").ToList();
            foreach (Student student in class12)
            {
                Console.WriteLine("Name: {0} | Eyes: {1}", student.Name, student.Eyes);
            }
        };

        static Action<IList<Student>> SocialHandler = students =>
        {
            Console.WriteLine("\nExecuting Filter SocialSit");
            IEnumerable<Student> social = from student in students
                                          where student.ScheduleAction.Contains("SocialSit")
                                          orderby student.Class, student.Name
                                          select student;

            foreach (Student student in social)
            {
                Console.WriteLine("Class: {0} | Name: {1} | Scheduled Action: {2}", student.Class, student.Name, student.ScheduleAction);
            }
        };

        static Action<IList<Student>> LockerHandler = students =>
        {
            Console.WriteLine("\nExecuting Filter LockerSize AVG");
            double avg = students.Average(x => Convert.ToDouble(x.LockerSize));
            Console.WriteLine("avg locker size {0}", avg);

            IEnumerable<Student> lockers = (from student in students
                                            orderby student.LockerSize descending
                                            select student).Take(5);

            Console.WriteLine("top 5 locker sizes:");
            foreach (Student student in lockers)
            {
                Console.WriteLine("Name: {0} | LockerSize: {1}", student.Name, student.LockerSize);
            }
        };        
    }
}
