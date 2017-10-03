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
    class Menu : IComposite
    {
        private List<IComposite> composites;

        public void Add(IComposite Composite)
        {
            composites.Add(Composite);
        }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public string GetKeyWord()
        {
            return "menu";
        }

        public IObservable GetObservable()
        {
            return new menuObservable();
        }

        
    }
}
