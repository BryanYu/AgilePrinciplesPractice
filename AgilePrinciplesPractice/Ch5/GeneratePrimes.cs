using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch5
{
    /// <summary>
    /// 產生質數程式
    /// </summary>
    public class PrimeGenerator
    {
        private static int s;
        private static bool[] isCrossed;
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
                InitialieArrayOfIntegers(maxValue);
                CrossOutMultiples();
                Sieve();
                LoadPrimes();
                return result;
            }
        }

        private static void CrossOutMultiples()
        {
            int maxPrimeFactor = CalcMaxPrimeFactor();
            for (int i = 2; i < maxPrimeFactor + 1; i++)
            {
                if (NotCrossed(i))
                {
                    CrossOutMultiplesOf(i);
                }
            }
        }

        private static bool NotCrossed(int i)
        {
            return isCrossed[i] == false;
        }

        private static void CrossOutMultiplesOf(int i)
        {
            for (int multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
            {
                isCrossed[multiple] = true;
            }
        }

        private static int CalcMaxPrimeFactor()
        {
            double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
            return (int)maxPrimeFactor;
        }

        private static void LoadPrimes()
        {
            // 有多少個質數?
            int i;
            int j;
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (isCrossed[i])
                {
                    count++;
                }
            }

            result = new int[count];
            // 把質數轉移到結果陣列中
            for (i = 0, j = 0; i < s; i++)
            {
                if (isCrossed[i])
                {
                    result[j++] = i;
                }
            }
        }

        private static void Sieve()
        {
            // sieve (篩選；過濾)
            int i;
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (isCrossed[i]) // 如果i未被劃掉，就劃掉其倍數
                {
                    for (j = 2 * i; j < s; j += i)
                    {
                        isCrossed[j] = false; // 倍數不是質數
                    }
                }
            }
        }

        private static void InitialieArrayOfIntegers(int maxValue)
        {
            isCrossed = new bool[maxValue + 1];
            isCrossed[0] = isCrossed[1] = false;
            //陣列元素初始為true
            for (int i = 2; i < isCrossed.Length; i++)
            {
                isCrossed[i] = true;
            }
        }
    }
}