using Stack_App.Entities;
using System;
using System.Collections.Generic;

namespace Stack_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size;
            int option;
            int subOption1;
            int subOption2;
            string name;
            string lastname;
            int number;                       

            Console.WriteLine("Hi!\nChoose a collection size");
            size = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine("Max size " + size);
            Stack<Student> theStack = new Stack<Student>();
            do
            {
                Console.WriteLine("Choose an option:\n1. Push or Pop operations\n2. Show items\n3. Exit");
                option = Convert.ToInt32(Console.ReadLine());

                if (option != 3)
                {
                    if (option == 1)
                    {
                        Console.WriteLine("Choose an option:\n1. Push\n2. Pop\n3. Back");
                        subOption1 = Convert.ToInt32(Console.ReadLine());
                        if (subOption1 != 3)
                        {
                            if (subOption1 == 1)
                            {
                                try
                                {
                                    Console.WriteLine("Student name: ");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Student lastname: ");
                                    lastname = Console.ReadLine();
                                    theStack.Push(new Student() { FirstName = name, LastName = lastname });
                                }
                                catch (MyStackOverflowException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    theStack.Pop();
                                }
                                catch (MyStackUnderFlowException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Introduce desired option:\n1. Default\n2. TopBottom\n3. BottomTop\n4. TopN\n5. Back");
                        subOption2 = Convert.ToInt32(Console.ReadLine());
                        switch (subOption2)
                        {
                            case 1:
                                {
                                    foreach (Student student in theStack)
                                    {
                                        student.GetName();
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            case 2:
                                {
                                    foreach (Student student in theStack.TopToBottom)
                                    {
                                        student.GetName();
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            case 3:
                                {
                                    foreach (Student student in theStack.BottomToTop)
                                    {
                                        student.GetName(); 
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("How many elements?");
                                    number = Convert.ToInt32(Console.ReadLine());
                                    foreach (Student student in theStack.TopN(number))
                                    {
                                        student.GetName();
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            case 5:
                                {
                                    break;
                                }
                        }
                    }

                }
            } while (option != 3); 
            
            Console.ReadKey();            
        }
    }    
}