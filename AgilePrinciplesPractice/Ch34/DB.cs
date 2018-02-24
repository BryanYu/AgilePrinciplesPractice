using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;

namespace AgilePrinciplesPractice.Ch34
{
    public class DB
    {
        private static SqlConnection connection;

        public static void Init()
        {
            string connectionString = "Intial Catelog=QuickMart;" +
                                      "Data Source=marvin;" +
                                      "user id=sa;password=abc;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public static void Close()
        {
            connection.Close();
        }

        public static void DeleteProductData(string sku)
        {
            BuildProductDeleteStatement(sku).ExecuteNonQuery();
        }

        public static ProductData GetProductData(string sku)
        {
            SqlCommand command = BuildProductQueryCommand(sku);
            IDataReader reader = ExecuteQueryStatement(command);
            ProductData pd = ExtractProductDataFromReader(reader);
            reader.Close();
            return pd;
        }

        public static void Store(ProductData pd)
        {
            SqlCommand command = BuildInsertionCommand(pd);
            command.ExecuteNonQuery();
        }

        public static OrderData NewOrder(string customerId)
        {
            string sql = "INSERT INTO Orders(custId) VALUES(@custId);" + "SELECT scope_identity()";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@custId", customerId);
            int newOrderId = Convert.ToInt32(command.ExecuteScalar());
            return new OrderData(newOrderId, customerId);
        }

        public static ItemData[] GetItemsForOrders(int orderId)
        {
            SqlCommand command = BuildItemsForOrderQueryStatement(orderId);
            IDataReader reader = command.ExecuteReader();
            ItemData[] id = ExtractItemDataFromResultSet(reader);
            reader.Close();
            return id;
        }

        public static void Store(ItemData id)
        {
            SqlCommand command = BuildInsertionCommand(id);
            command.ExecuteNonQuery();
        }

        public static OrderData GetOrderData(int orderId)
        {
            string sql = "SELECT cusid FROM orders" + "WHERE orderid = @orderId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@orderId", orderId);
            IDataReader reader = command.ExecuteReader();
            OrderData od = null;
            if (reader.Read())
            {
                od = new OrderData(orderId, reader["custid"].ToString());
            }
            reader.Close();
            return od;
        }

        public static void Clear()
        {
            ExecuteSQL("DELETE FROM Items");
            ExecuteSQL("DELETE FROM Orders");
            ExecuteSQL("DELETE FROM Products");
        }

        private static void ExecuteSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static ItemData[] ExtractItemDataFromResultSet(IDataReader reader)
        {
            ArrayList items = new ArrayList();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["orderId"]);
                int quantity = Convert.ToInt32(reader["quantity"]);
                string sku = reader["sku"].ToString();

                ItemData id = new ItemData(orderId, quantity, sku);
                items.Add(id);
            }

            return (ItemData[])items.ToArray(typeof(ItemData));
        }

        private static SqlCommand BuildItemsForOrderQueryStatement(int orderId)
        {
            string sql = "SELECT * FROM Items" + "WHERE orderid = @orderId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@orderId", orderId);
            return command;
        }

        private static IDataReader ExecuteQueryStatement(SqlCommand command)
        {
            IDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader;
        }

        private static SqlCommand BuildProductDeleteStatement(string sku)
        {
            string sql = "DELETE FROM Products WHERE sku = @sku";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@sku", sku);
            return command;
        }

        private static ProductData ExtractProductDataFromReader(IDataReader reader)
        {
            ProductData pd = new ProductData();
            pd.Sku = reader["sku"].ToString();
            pd.Name = reader["Name"].ToString();
            pd.Price = Convert.ToInt32(reader["price"]);
            return pd;
        }

        private static SqlCommand BuildProductQueryCommand(string sku)
        {
            string sql = "SELECT * FROM Products WHERE sku = @sku";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@sku", sku);
            return command;
        }

        private static SqlCommand BuildInsertionCommand(ProductData pd)
        {
            string sql = "INSERT INTO Products VALUES(@sku,@name,@price)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@sku", pd.Sku);
            command.Parameters.Add("@price", pd.Price);
            command.Parameters.Add("@name", pd.Name);
            return command;
        }

        private static SqlCommand BuildInsertionCommand(ItemData pd)
        {
            string sql = "INSERT INTO Items(orderId,quantity,sku) VALUES(@orderId,@quantity,@sku)";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@orderId", pd.orderId);
            command.Parameters.Add("@quantity", pd.qty);
            command.Parameters.Add("@sku", pd.sku);
            return command;
        }
    }
}