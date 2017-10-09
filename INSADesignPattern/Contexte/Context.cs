using INSADesignPattern.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Contexte
{
    class Context
    {

        public IComposite CurrentComposite { get; set; }
        public string UserName { get; set; }

        public Context()
        {
            CurrentComposite = null;
            UserName = "mdr";
        }

    }
}
