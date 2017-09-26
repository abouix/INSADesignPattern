using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Observer
{
    class Observer
    {
        private Dictionary<string, List<IObservable>> observables;

        public Observer()
        {
            observables = new Dictionary<string, List<IObservable>>();
        }


        //Register : enregistre un evenement dans le dico d'observables
        //ANCIENNE VERSION
        /*
        public void Register(string key, IObservable observable)
        {

            List<IObservable> listObs = new List<IObservable>();
            if (observables.ContainsKey(key)) {
                listObs = observables[key];
            }
            listObs.Add(observable);
            observables.Remove(key);
            observables.Add(key, listObs);
        }
        */


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

            //TODO Ajouter quand un observable renvoie false, ca arrete l'execution de celles d'apres
            
            if (observables.ContainsKey(key))
            { 
                List<IObservable> listObs = observables[key];

                foreach (var obs in listObs)
                {
                    obs.Execute();
                }
                return true;

            } else {
                return false;
            }
            
 
        }
    }
}
