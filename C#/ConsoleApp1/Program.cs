using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\nEnter your name.");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " welcome.\nNow please confirm your age to continue...");
            String age = Console.ReadLine();
            Console.WriteLine("Thanks for your information.\nYour name is " + name + " and your age is " + Convert.ToInt32(age));
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
