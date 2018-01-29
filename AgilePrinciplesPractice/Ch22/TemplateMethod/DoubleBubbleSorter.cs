using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch22.TemplateMethod
{
    public class DoubleBubbleSorter : BubbleSorter
    {
        private double[] array = null;

        public int Sort(double[] theArray)
        {
            array = theArray;
            length = theArray.Length;
            return DoSort();
        }

        protected override void Swap(int index)
        {
            double temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }

        protected override bool OutOfOrder(int index)
        {
            return (array[index] > array[index + 1]);
        }
    }
}