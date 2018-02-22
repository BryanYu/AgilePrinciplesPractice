using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch32
{
    public class Subject
    {
        private ArrayList observer = new ArrayList();

        public void NotifyObservers()
        {
            foreach (Observer observer in this.observer)
            {
                observer.Update();
            }
        }

        public void RegisterObserver(Observer observer)
        {
            this.observer.Add(observer);
        }
    }
}