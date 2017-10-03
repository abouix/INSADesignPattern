using INSADesignPattern.Observer;
using INSADesignPattern.InputStrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class helloObservable : IObservable
    {

        public IInputStrategy InputStrat { get; set; }

        public bool Execute()
        {
            return InputStrat.RunInputStrategy();
            
        }
    }
}
