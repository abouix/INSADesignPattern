using INSADesignPattern.InputStrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Strategies
{
    class FirstStrategy : IInputStrategy
    {

        public bool RunInputStrategy()
        {
            Console.WriteLine("mdr prenom");
            string name = Console.ReadLine();

            //On enregistre le Name (defini dans Program)
            Program.Name = name;

            Console.WriteLine("bjr " + name);
            return true;
        }
    }
}
