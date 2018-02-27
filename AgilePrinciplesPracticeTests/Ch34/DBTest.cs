using System;
using AgilePrinciplesPractice.Ch34;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch34
{
    [TestFixture]
    public class DBTest
    {
        [SetUp]
        public void SetUp()
        {
            DB.Init();
        }

        [TearDown]
        public void TearDown()
        {
            DB.Close();
        }

        [Test]
        public void StoreProduct()
        {
            ProductData storedProduct = new ProductData("MyProduct", 1234, "999");
            DB.Store(storedProduct);

            ProductData retrievedProduct = DB.GetProductData("999");
            DB.DeleteProductData("999");
            Assert.AreEqual(storedProduct, retrievedProduct);
        }

        [Test]
        public void OrderKeyGenerate()
        {
            OrderData o1 = DB.NewOrder("Bob");
            OrderData o2 = DB.NewOrder("Bill");
            int firstOrderId = o1.OrderId;
            int secondOrderId = o2.OrderId;
            Assert.AreEqual(firstOrderId + 1, secondOrderId);
        }

        [Test]
        public void StoreItem()
        {
            ItemData storeItem = new ItemData(1, 3, "sku");
            DB.Store(storeItem);
            ItemData[] retrievedItems = DB.GetItemsForOrders(1);
            Assert.AreEqual(1, retrievedItems.Length);
            Assert.AreEqual(storeItem, retrievedItems[0]);
        }

        [Test]
        public void NoItems()
        {
            ItemData[] id = DB.GetItemsForOrders(42);
            Assert.AreEqual(0, id.Length);
        }
    }
}