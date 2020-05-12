using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Original
            int[] numbers = new int[10];
            Random rnd = new Random();

            Console.WriteLine("Original order: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(100);
                Console.Write(numbers[i] + "-");
            }

            //2) Sort asc
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nSort asc: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "-");
            }

            //2) Sort desc
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nSort desc: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "-");
            }

            //3)  
            int num;
            Console.WriteLine("\nPick a number:");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number {0} is in index N°:{1}", num, Array.IndexOf(numbers, num));

            //4) 
            Console.WriteLine("\nOriginal text: ");
            string texto = "The cat is black";
            Console.WriteLine(texto);            

            StringBuilder sb = new StringBuilder();
            sb.Append(texto);
            sb.Replace("black", "white");

            Console.WriteLine("\nModified text: ");
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
