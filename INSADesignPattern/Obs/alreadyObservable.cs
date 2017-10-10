using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class alreadyObservable : IObservable
    {
        public bool Execute()
        {
            Console.WriteLine("You are already in " + Program.context.CurrentComposite.GetDescription());
            return true;
        }
    }
}
