using INSADesignPattern.Composite;
using INSADesignPattern.Obs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Observer
{

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
                //New Methode
                ManageComposite();
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool ManageComposite()
        {
            //Remise a 0 du dictionnaire d'Observables (désenregistre tout)
            observables = new Dictionary<string, List<IObservable>>();

            //Recuperation du composite courant
            IComposite composite = Program.context.CurrentComposite;

            //Fils directs
            List<IComposite> sons = composite.GetSons();

            //Enregistrement des fils
            foreach (var son in sons)
            {
                Register(son.GetKeyWord(), son.GetObservable());
            }

            //Register le alreadyObs pour la prochaine fois qu'on ecrira
            Register(composite.GetKeyWord(), new alreadyObservable());

            return true;

        }
        /// <summary>
        /// mdr
        /// </summary>
        /// <returns></returns>
        public bool BackMenu()
        {
            //Remise a 0 du dictionnaire d'Observables (désenregistre tout)
            observables = new Dictionary<string, List<IObservable>>();

            //Fils du parent
            List<IComposite> sons = Program.context.CurrentComposite.Parent.GetSons();

            //Enregistrement des fils du parent
            foreach (var son in sons)
            {
                Register(son.GetKeyWord(), son.GetObservable());
            }

            return true;
        }


    }
}
