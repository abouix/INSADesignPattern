using INSADesignPattern.Obs;
using INSADesignPattern.InputStrat;
using INSADesignPattern.Strategies;
using INSADesignPattern.Contexte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSADesignPattern.Observer;
using INSADesignPattern.Composite;

namespace INSADesignPattern
{
    class Program
    {

        //On definit un attribut Name
        public static string Name { get; set; }

        public static Context context;

        //On peut faire methode UserSaidHello
        //On peut mettre les obs en static ici

        static void Main(string[] args)
        {

            context = new Context();

            
            Observer.Observer observer = new Observer.Observer();
            /*
            helloObservable helloObs = new helloObservable();
            smileyObservable smileyObs = new smileyObservable();

            observer.Register("hello", smileyObs);
            observer.Register("hello", helloObs);

            
            int helloCount=0;
            */
            string line;

            NewObserver newObserver = new NewObserver();
            IComposite tmp;

            //Creation des composites
            Composites.Composite menu = new Composites.Composite("Menu", "menu", new compObservable());
            Composites.Composite partieR = new Composites.Composite("Partie Rapide", "jouer", new compObservable());
            Composites.Composite typeP = new Composites.Composite("Type Partie", "type", new compObservable());
            Composites.Composite chrono = new Composites.Composite("Chronométrée", "timed", new compObservable());
            Composites.Composite infinie = new Composites.Composite("Infinie", "endless", new compObservable());
            Composites.Composite objectif = new Composites.Composite("Objectif", "points", new compObservable());
            Composites.Composite score = new Composites.Composite("Score", "score", new compObservable());

            /*
            //Fin de l'arbre
            Composites.Composite  = new Composites.Composite("Score", "score", new compObservable());
            Composites.Composite score = new Composites.Composite("Score", "score", new compObservable());
            Composites.Composite score = new Composites.Composite("Score", "score", new compObservable());
            Composites.Composite score = new Composites.Composite("Score", "score", new compObservable());
            Composites.Composite score = new Composites.Composite("Score", "score", new compObservable());
            */


            //Construction de l'arbre
            menu.AddSon(partieR);
            menu.AddSon(typeP);
            menu.AddSon(score);

            typeP.AddSon(chrono);
            typeP.AddSon(infinie);
            typeP.AddSon(objectif);

            //Ajout des parents
            partieR.Parent = menu;
            typeP.Parent = menu;
            score.Parent = menu;

            chrono.Parent = typeP;
            infinie.Parent = typeP;
            objectif.Parent = typeP;

            //Dictionnaires de composites pour MaJ le current composite
            Dictionary<string, IComposite> composites = new Dictionary<string, IComposite>();
            composites.Add(menu.GetKeyWord(), menu);
            composites.Add(partieR.GetKeyWord(), partieR);
            composites.Add(typeP.GetKeyWord(), typeP);
            composites.Add(chrono.GetKeyWord(), chrono);
            composites.Add(infinie.GetKeyWord(), infinie);
            composites.Add(objectif.GetKeyWord(), objectif);
            composites.Add(score.GetKeyWord(), score);


            //Register le menu
            newObserver.Register(menu.GetKeyWord(), menu.GetObservable());

            observer.Register("back", new backObservable());

            context.CurrentComposite = menu;


            Console.WriteLine("");
            Console.WriteLine("     __   __     __  ________  _____");
            Console.WriteLine("    /  / /  |  /  / /  _____/ /  _  |");
            Console.WriteLine("   /  / /   | /  / /  /____  /  /_| |");
            Console.WriteLine("  /  / /    |/  / /____   / /  ___  |");
            Console.WriteLine(" /  / /  /|    / _____/  / /  /   | |");
            Console.WriteLine("/__/ /__/ |___/ /_______/ /__/    |_|");
            Console.WriteLine("Desing Patterns - Anthony Maudry amaudry@gmail.com");
            Console.WriteLine("Hello,");
            Console.WriteLine("Write something (type 'exit' to exit the program).");
            Console.WriteLine("Write menu to access Menu");


            while ((line = Console.ReadLine()) != "exit")
            {

                if (line.Equals("back") && !context.CurrentComposite.Equals(menu))
                {

                    observer.Trigger(line);
                    newObserver.BackMenu();
                    tmp = context.CurrentComposite;
                    context.CurrentComposite = tmp.Parent;                  
                    
                } else if (context.CurrentComposite.GetSons().Exists(p => p.GetKeyWord().Equals(line)) || context.CurrentComposite.GetKeyWord().Equals(line))
                {
                    context.CurrentComposite = composites[line];
                    newObserver.Trigger(line);
                } else {
                    Console.WriteLine("You wrote : ");
                    Console.WriteLine(line);
                }
                
                /*
                if (line.Equals("hello")) 
                {
                    helloCount++;

                    switch (helloCount) {
                        case 1:
                            helloObs.InputStrat = new FirstStrategy();
                            break;
                        case 2:
                            helloObs.InputStrat = new SecondStrategy();
                            break;
                        case 6:
                            helloObs.InputStrat = new ThirdStrategy();
                            break;
                        default:
                            break;
                    }
                }

                if (!observer.Trigger(line)) 
                { 
                    Console.WriteLine("You wrote : ");
                    Console.WriteLine(line);
                }
                */

            }

            Console.WriteLine("Goodbye.");
        }
    }
}
