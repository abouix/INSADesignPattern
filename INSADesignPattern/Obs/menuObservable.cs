using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Obs
{
    class menuObservable : IObservable
    {
        public bool Execute()
        {
            Console.Write("test");
        }
    }
}

//Faire un nouvel observer avec une méthode permettant de créer une nouvelle liste (dans le trigger), de recup le composite ainsi que tous les fils direct de ce composite et de les renregistrer apres le trigger
//ALEXANDRE : comment retourner dans le menu? (peut etre liste parents pour les composites)
//Creer observables pour chaque Composite?

