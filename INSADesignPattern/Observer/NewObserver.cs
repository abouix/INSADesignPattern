using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Observer
{

    //Méthode qui recupere le contexte et fait tout ce qu'il y a en dessous
    //Faire un nouvel observer avec une méthode permettant de créer une nouvelle liste (dans le trigger), de recup le composite ainsi que tous les fils direct de ce composite et de les renregistrer apres le trigger
    //ALEXANDRE : comment retourner dans le menu? (peut etre liste parents pour les composites)
    //Creer observables pour chaque Composite?
    class NewObserver
    {
        private Dictionary<string, List<IObservable>> observables;

        public NewObserver()
        {
            observables = new Dictionary<string, List<IObservable>>();
        }

        public void Register(string key, IObservable observable)
        {

            if (!observables.ContainsKey(key))
            {
                observables.Add(key, new List<IObservable>());
            }
            //On recupere la liste grace au Single.Value (et la fonction filtre) et on ajoute directement le nouvel elt
            observables.Single(p => p.Key == key).Value.Add(observable);
        }


        //Unregister : contraire du precedent
        public void Unregister(string key, IObservable observable)
        {

            if (observables.ContainsKey(key))
            {

                observables.Single(p => p.Key == key).Value.Remove(observable);
            }

        }

        //Trigger : declenche un evenement d'un observable
        public bool Trigger(string key)
        {

            if (observables.ContainsKey(key))
            {
                List<IObservable> listObs = observables[key];

                foreach (var obs in listObs)
                {
                    //Si l'exec renvoie faux, alors trigger retourne vrai (ou faux) et les autres obs ne sont pas exécutés
                    if (!obs.Execute())
                    {
                        return true;
                    }
                }


                return true;

            }
            else
            {
                return false;
            }


        }
    }
}
