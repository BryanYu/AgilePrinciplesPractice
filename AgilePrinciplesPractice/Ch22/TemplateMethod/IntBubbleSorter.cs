using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch22.TemplateMethod
{
    public class IntBubbleSorter : BubbleSorter
    {
        private int[] array = null;

        public int Sort(int[] theArray)
        {
            array = theArray;
            length = theArray.Length;
            return DoSort();
        }

        protected override void Swap(int index)
        {
            int temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }

        protected override bool OutOfOrder(int index)
        {
            return (array[index] > array[index + 1]);
        }
    }
}