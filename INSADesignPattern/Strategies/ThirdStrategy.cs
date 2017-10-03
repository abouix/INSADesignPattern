using INSADesignPattern.InputStrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Strategies
{
    class ThirdStrategy : IInputStrategy
    {
        public bool RunInputStrategy()
        {
            Console.WriteLine("ok c'est pas drole " + Program.Name);
            return true;
        }
    }
}
