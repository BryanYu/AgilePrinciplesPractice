using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch34;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch34
{
    [TestFixture]
    public class ProxyTest
    {
        [SetUp]
        public void SetUp()
        {
            DB.Init();
            ProductData pd = new ProductData();
            pd.Sku = "ProxyTest1";
            pd.Name = "ProxyTestName1";
            pd.Price = 456;
            DB.Store(pd);
        }

        [TearDown]
        public void TearDown()
        {
            DB.DeleteProductData("ProxyTest1");
            DB.Close();
        }

        [Test]
        public void ProductProxy()
        {
            Product p = new ProductProxy("ProxyTest1");
            Assert.AreEqual(456, p.Price);
            Assert.AreEqual("ProxyTestName1", p.Name);
            Assert.AreEqual("ProxyTest1", p.Sku);
        }
    }
}