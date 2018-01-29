using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch22.Strategy
{
    public class IntSortHandler : SortHandler
    {
        private int[] array = null;

        public void Swap(int index)
        {
            int temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }

        public bool OutOfOrder(int index)
        {
            return (array[index] > array[index + 1]);
        }

        public int Length()
        {
            return array.Length;
        }

        public void SetArray(object array)
        {
            this.array = (int[])array;
        }
    }
}