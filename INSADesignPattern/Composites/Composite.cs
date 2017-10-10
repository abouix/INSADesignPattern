using INSADesignPattern.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSADesignPattern.Observer;

namespace INSADesignPattern.Composites
{
    class Composite : IComposite
    {

        private string desc;
        private string key;
        private IObservable obs;
        public IComposite Parent { get; set; }


        private List<IComposite> sonsList=null;

        public Composite(string inputDesc, string inputKey, IObservable inputObs)
        {
            desc = inputDesc;
            key = inputKey;
            obs = inputObs;
            sonsList = new List<IComposite>();
            Parent = null;
        }

        public string GetDescription()
        {
            return desc;
        }

        public string GetKeyWord()
        {
            return key;
        }

        public IObservable GetObservable()
        {
            return obs;
        }

        public void AddSon(IComposite son)
        {
            sonsList.Add(son);
        }

        public List<IComposite> GetSons()
        {
            return sonsList;
        }

        public bool DisplaySons()
        {
            if (sonsList.Count > 0)
            {
                Console.WriteLine(desc + " <" + key + ">");
                foreach (var son in sonsList)
                {
                    Console.WriteLine("---- " + son.GetDescription() + " <" + son.GetKeyWord() + ">");
                }
            } else
            {
                Console.WriteLine("beaf");
            }
            return true;
        }

    }
}
