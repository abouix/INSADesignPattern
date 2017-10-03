using INSADesignPattern.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSADesignPattern.Observer;
using INSADesignPattern.Obs;

namespace INSADesignPattern.Composites
{
    class TypePartie : IComposite
    {
        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public string GetKeyWord()
        {
            return "type";
        }

        public IObservable GetObservable()
        {
            return new menuObservable();
        }
    }
}
