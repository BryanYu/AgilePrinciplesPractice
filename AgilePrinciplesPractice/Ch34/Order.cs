using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace AgilePrinciplesPractice.Ch34
{
    public interface Product
    {
        int Price { get; }

        string Name { get; }

        string Sku { get; }
    }

    public interface Order
    {
        string CustomerId { get; }

        int Total { get; }

        void AddItem(Product p, int quantity);
    }

    public class ProductImpl : Product
    {
        private int price;
        private string name;
        private string sku;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Sku
        {
            get
            {
                return this.sku;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
        }

        public ProductImpl(int price, string name, string sku)
        {
            this.price = price;
            this.name = name;
            this.sku = sku;
        }
    }

    public class ProductProxy : Product
    {
        private string sku;

        public int Price
        {
            get
            {
                ProductData pd = DB.GetProductData(sku);
                return pd.Price;
            }
        }

        public string Name
        {
            get
            {
                ProductData pd = DB.GetProductData(sku);
                return pd.Name;
            }
        }

        public string Sku
        {
            get
            {
                return this.sku;
            }
        }

        public ProductProxy(string sku)
        {
            this.sku = sku;
        }
    }

    public class Item
    {
        private readonly Product product;

        private readonly int qty;

        public Product Product
        {
            get
            {
                return this.product;
            }
        }

        public int Quantity
        {
            get
            {
                return this.qty;
            }
        }

        public Item(Product product, int qty)
        {
            this.product = product;
            this.qty = qty;
        }
    }

    public class OrderImp : Order
    {
        private string customerId;
        private ArrayList items = new ArrayList();

        public string CustomerId
        {
            get
            {
                return this.customerId;
            }
        }

        public int Total
        {
            get
            {
                int total = 0;
                foreach (Item item in this.items)
                {
                    Product p = item.Product;
                    int qty = item.Quantity;
                    total += p.Price * qty;
                }

                return total;
            }
        }

        public OrderImp(string customerId)
        {
            this.customerId = customerId;
        }

        public void AddItem(Product p, int quantity)
        {
            Item item = new Item(p, quantity);
            this.items.Add(item);
        }
    }

    public class OrderProxy : Order
    {
        private int orderId;

        public int OrderId
        {
            get
            {
                return this.orderId;
            }
        }

        public string CustomerId
        {
            get
            {
                OrderData od = DB.GetOrderData(this.orderId);
                return od.CustomerId;
            }
        }

        public int Total
        {
            get
            {
                OrderImp imp = new OrderImp(CustomerId);
                ItemData[] itemDataArray = DB.GetItemsForOrders(this.orderId);
                foreach (ItemData itemData in itemDataArray)
                {
                    imp.AddItem(new ProductProxy(itemData.sku), itemData.qty);
                }

                return imp.Total;
            }
        }

        public OrderProxy(int orderId)
        {
            this.orderId = orderId;
        }

        public void AddItem(Product p, int quantity)
        {
            ItemData id = new ItemData(this.orderId, quantity, p.Sku);
            DB.Store(id);
        }
    }

    public class ItemData
    {
        public int orderId;

        public int qty;

        public string sku = "junk";

        public ItemData()
        {
        }

        public ItemData(int orderId, int qty, string sku)
        {
            this.orderId = orderId;
            this.qty = qty;
            this.sku = sku;
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemData)
            {
                ItemData id = obj as ItemData;

                return this.orderId == id.orderId && this.qty == id.qty && this.sku.Equals(id.sku);
            }

            return false;
        }
    }
}