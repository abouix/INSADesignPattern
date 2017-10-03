using INSADesignPattern.InputStrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Strategies
{
    class SecondStrategy : IInputStrategy
    {
        public bool RunInputStrategy()
        {
            Console.WriteLine("je te reconnais " + Program.Name);
            return true;
        }
    }
}
