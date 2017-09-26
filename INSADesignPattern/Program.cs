using INSADesignPattern.Obs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {


            Observer.Observer observer = new Observer.Observer();

            helloObservable helloObs = new helloObservable();
            smileyObservable smileyObs = new smileyObservable();

            observer.Register("hello", smileyObs);
            observer.Register("hello", helloObs);

            string line;
            Console.WriteLine("");
            Console.WriteLine("     __   __     __  ________  _____");
            Console.WriteLine("    /  / /  |  /  / /  _____/ /  _  |");
            Console.WriteLine("   /  / /   | /  / /  /____  /  /_| |");
            Console.WriteLine("  /  / /    |/  / /____   / /  ___  |");
            Console.WriteLine(" /  / /  /|    / _____/  / /  /   | |");
            Console.WriteLine("/__/ /__/ |___/ /_______/ /__/    |_|");
            Console.WriteLine("Desing Patterns - Anthony Maudry amaudry@gmail.com");
            Console.WriteLine("Hello,");
            Console.WriteLine("Write something (type 'exit' to exit the program).");

            while ((line = Console.ReadLine()) != "exit")
            {
                if (!observer.Trigger(line)) { 
                    Console.WriteLine("You wrote : ");
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("Goodbye.");
        }
    }
}
