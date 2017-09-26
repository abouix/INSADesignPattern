using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class smileyObservable : IObservable
    {
        public bool Execute()
        {
            Console.WriteLine(":d");
            return true;
        }
    }
}
