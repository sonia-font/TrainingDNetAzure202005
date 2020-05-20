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
            string name;
            string lastname;
                                  

            Console.WriteLine("Hi!\nChoose a collection size");
            size = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine("Max size " + size);
            Stack<Student> theStack = new Stack<Student>();
            do
            {                
                Console.WriteLine("Choose an option:\n1. Push\n2. Pop\n3. Exit");
                option = Convert.ToInt32(Console.ReadLine());
                if (option != 3)
                {
                    if (option == 1)
                    {
                        try
                        {
                            Console.WriteLine("Student name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Student lastname: ");
                            lastname = Console.ReadLine();
                            theStack.Push(new Student() { FirstName = name, LastName = lastname });
                        }
                        catch (Exception)
                        {
                            throw new MyStackOverflowException("Stack full");
                        }
                    }
                    else
                    {
                        try
                        {
                            theStack.Pop();
                        }
                        catch (Exception)
                        {
                            throw new MyStackUnderFlowException("Stack is empty");
                        }
                    }
                }                
                
            } while (option != 3); 
            
            Console.ReadKey();            
        }
    }

    public class MyStackOverflowException : Exception
    {
        public MyStackOverflowException(string message)
            : base(message)
        {
        }
    }

    public class MyStackUnderFlowException : Exception
    {
        public MyStackUnderFlowException(string message)
            : base(message)
        {
        }
    }
}