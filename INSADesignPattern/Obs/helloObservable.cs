using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class helloObservable : IObservable
    {
        public bool Execute()
        {
            Console.WriteLine("mdr prenom");
            string name = Console.ReadLine();
            Console.WriteLine("bjr " + name);
            return true;
        }
    }
}
