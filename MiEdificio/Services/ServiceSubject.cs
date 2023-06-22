using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class ServiceSubject
    {

        public static List<IObserverIdioma> observers = new List<IObserverIdioma>();
        public static void Attach(IObserverIdioma i)
        {
            observers.Add(i);
        }

        public static void Dettach(IObserverIdioma i)
        {
            observers.Remove(i);
        }

        public void Notify(ServiceIdioma idioma)
        {
            foreach (var observ in observers)
            {
                observ.UpdateIdioma(idioma);
            }
        }


    }
}
