using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch22.TemplateMethod
{
    public abstract class BubbleSorter
    {
        protected int length = 0;
        private static int operation = 0;

        protected int DoSort()
        {
            operation = 0;
            if (length <= 1)
            {
                return operation;
            }

            for (int nextToLast = length - 2; nextToLast >= 0; nextToLast--)
            {
                for (int index = 0; index <= nextToLast; index++)
                    if (OutOfOrder(index))
                    {
                        Swap(index);
                    }

                operation++;
            }

            return operation;
        }

        protected abstract void Swap(int index);

        protected abstract bool OutOfOrder(int index);
    }
}