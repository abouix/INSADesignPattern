using INSADesignPattern.Obs;
using INSADesignPattern.InputStrat;
using INSADesignPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern
{
    class Program
    {

        //On definit un attribut Name
        public static string Name { get; set; }

        static void Main(string[] args)
        {

            

            Observer.Observer observer = new Observer.Observer();

            helloObservable helloObs = new helloObservable();
            smileyObservable smileyObs = new smileyObservable();

            observer.Register("hello", smileyObs);
            observer.Register("hello", helloObs);

            string line;
            int helloCount=0;

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

                if (line.Equals("hello")) 
                {
                    helloCount++;

                    switch (helloCount) {
                        case 1:
                            helloObs.InputStrat = new FirstStrategy();
                            break;
                        case 2:
                            helloObs.InputStrat = new SecondStrategy();
                            break;
                        case 6:
                            helloObs.InputStrat = new ThirdStrategy();
                            break;
                        default:
                            break;
                    }
                }

                if (!observer.Trigger(line)) 
                { 
                    Console.WriteLine("You wrote : ");
                    Console.WriteLine(line);
                }

            }

            Console.WriteLine("Goodbye.");
        }
    }
}
