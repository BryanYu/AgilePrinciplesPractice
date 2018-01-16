using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch5;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch5
{
    [TestFixture]
    public class GeneratePrimesTest
    {
        [Test]
        public void TestPrimes()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
            Assert.AreEqual(nullArray.Length, 0);

            int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
            Assert.AreEqual(minArray.Length, 1);
            Assert.AreEqual(minArray[0], 2);

            int[] threeArray = PrimeGenerator.GeneratePrimeNumbers(3);
            Assert.AreEqual(threeArray.Length, 2);
            Assert.AreEqual(threeArray[0], 2);
            Assert.AreEqual(threeArray[1], 3);

            int[] centArray = PrimeGenerator.GeneratePrimeNumbers(100);
            Assert.AreEqual(centArray.Length, 25);
            Assert.AreEqual(centArray[24], 97);
        }

        public void TestExhaustive()
        {
            for (int i = 2; i < 500; i++)
            {
                VerifyPrimeList(PrimeGenerator.GeneratePrimeNumbers(i));
            }
        }

        private void VerifyPrimeList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                VerifyPrime(list[i]);
            }
        }

        private void VerifyPrime(int n)
        {
            for (int factor = 2; factor < n; factor++)
            {
                Assert.IsTrue(n % factor != 0);
            }
        }
    }
}