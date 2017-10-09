using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class compObservable : IObservable
    {
        public bool Execute()
        {
            //Execute la méthode displaySOns du composite
            return Program.context.CurrentComposite.DisplaySons();
        }
    }
}
