using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class backObservable : IObservable
    {
        public bool Execute()
        {
            Console.WriteLine("Retour en arriere");
            return Program.context.CurrentComposite.Parent.DisplaySons();
        }
    }
}
