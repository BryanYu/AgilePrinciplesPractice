using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch24
{
    public class Singleton
    {
        private static Singleton thisInstance = null;

        public static Singleton Instance
        {
            get
            {
                if (thisInstance == null)
                {
                    thisInstance = new Singleton();
                }

                return thisInstance;
            }
        }

        private Singleton()
        {
        }
    }
}