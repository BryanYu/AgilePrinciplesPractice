using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch5
{
    /// <summary>
    /// 產生質數程式
    /// </summary>
    public class PrimeGenerator
    {
        private static bool[] crossedOut;
        private static int[] result;

        /// <summary>
        /// 產生一個包含質數的陣列
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0]; //若輸入不合理值，則回傳空陣列
            }
            else
            {
                UncrossIntegersUpTo(maxValue);
                CrossOutMultiples();
                PutUncrossedIntegersIntoResult();
                return result;
            }
        }

        private static void PutUncrossedIntegersIntoResult()
        {
            result = new int[NumberOfUncrossedIntegers()];
            for (int j = 0, i = 2; i < crossedOut.Length; i++)
            {
                if (NotCrossed(i))
                {
                    result[j++] = i;
                }
            }
        }

        private static int NumberOfUncrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < crossedOut.Length; i++)
            {
                if (NotCrossed(i))
                {
                    count++;
                }
            }

            return count;
        }

        private static void CrossOutMultiples()
        {
            int limit = DetermineIterationLimit();
            for (int i = 2; i <= limit; i++)
            {
                if (NotCrossed(i))
                {
                    CrossOutMultiplesOf(i);
                }
            }
        }

        private static bool NotCrossed(int i)
        {
            return crossedOut[i] == false;
        }

        private static void CrossOutMultiplesOf(int i)
        {
            for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
            {
                crossedOut[multiple] = true;
            }
        }

        private static int DetermineIterationLimit()
        {
            double iterationLimit = Math.Sqrt(crossedOut.Length);
            return (int)iterationLimit;
        }

        private static void UncrossIntegersUpTo(int maxValue)
        {
            crossedOut = new bool[maxValue + 1];
            //陣列元素初始為true
            for (int i = 2; i < crossedOut.Length; i++)
            {
                crossedOut[i] = false;
            }
        }
    }
}