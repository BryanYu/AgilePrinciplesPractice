using System;
using System.Collections.Generic;
using System.Linq;
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
        private static bool[] f;
        private static int[] primes;

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
                InitializeSieve(maxValue);
                Sieve();
                LoadPrimes();
                return primes;
            }
        }

        private static void LoadPrimes()
        {
            // 有多少個質數?
            int i;
            int j;
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i])
                {
                    count++;
                }
            }

            primes = new int[count];
            // 把質數轉移到結果陣列中
            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i])
                {
                    primes[j++] = i;
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
                if (f[i]) // 如果i未被劃掉，就劃掉其倍數
                {
                    for (j = 2 * i; j < s; j += i)
                    {
                        f[j] = false; // 倍數不是質數
                    }
                }
            }
        }

        private static void InitializeSieve(int maxValue)
        {
            s = maxValue + 1;
            f = new bool[s];
            int i;
            //陣列元素初始為true
            for (i = 0; i < s; i++)
            {
                f[i] = true;
            }

            // 去掉已知的非質數
            f[0] = f[1] = false;
        }
    }
}