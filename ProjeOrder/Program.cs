using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace ProjeOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetCustomers");
            request.Method = "GET";
            String testCustomer = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testCustomer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var CustomerList = JsonSerializer.Deserialize<List<Customers>>(testCustomer, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            foreach (Customers item in CustomerList)
            {
                Console.WriteLine("CustomerId:"+item.CustomerId);
            }
            Console.WriteLine("");
            Console.Write("CustomerId:");
            string customerId = Console.ReadLine();

            HttpWebRequest requestEmployee = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetEmployees");
            requestEmployee.Method = "GET";
            String testEmployee = String.Empty;
            using (HttpWebResponse responseEmployee = (HttpWebResponse)requestEmployee.GetResponse())
            {
                Stream dataStream = responseEmployee.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testEmployee = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                
            }
            var EmployeeList = JsonSerializer.Deserialize<List<Employees>>(testEmployee, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            foreach (Employees item in EmployeeList)
            {
                Console.WriteLine("EmployeeId:"+item.EmployeeId);
            }
            Console.WriteLine("");
            Console.Write("EmployeeId:");
            string EmployeeId = Console.ReadLine();

            HttpWebRequest requestProduct = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetProducts");
            requestProduct.Method = "GET";
            String testProduct = String.Empty;
            using (HttpWebResponse responseProduct = (HttpWebResponse)requestProduct.GetResponse())
            {
                Stream dataStream = responseProduct.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testProduct = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

            }
            var ProductList = JsonSerializer.Deserialize<List<Product>>(testProduct, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Product item in ProductList)
            {
                Console.WriteLine("ProductId:"+item.ProductId);
                Console.WriteLine("UnitPrice:"+item.UnitPrice);
            }
            Console.WriteLine("");
            Console.Write("ProductId:");
            var ProductId =Convert.ToInt32(Console.ReadLine());
            decimal unitprice = 0;
            foreach (Product item in ProductList)
            {
                if (item.ProductId==ProductId)
                {
                    unitprice = item.UnitPrice;
                }
            }

            HttpWebRequest requestShipper = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetShippers");
            requestShipper.Method = "GET";
            String testShipper = String.Empty;
            using (HttpWebResponse responseShipper = (HttpWebResponse)requestShipper.GetResponse())
            {
                Stream dataStream = responseShipper.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testShipper = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

            }
            var ShipperList = JsonSerializer.Deserialize<List<Shipper>>(testShipper, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Shipper item in ShipperList)
            {
                Console.WriteLine("ShipperId:" + item.ShipperId);
            }
            Console.WriteLine("");


            Console.Write("ShipperId:");
            string shipperId = Console.ReadLine();


            HttpWebRequest requestOrder = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/AddOrder?customerid="+customerId+"&employeeid="+EmployeeId+"&shipperid="+shipperId );
            requestOrder.Method = "POST";
            String testOrder = String.Empty;
            using (HttpWebResponse responseOrder = (HttpWebResponse)requestOrder.GetResponse())
            {
                Stream dataStream = responseOrder.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testOrder = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

            }
            HttpWebRequest requestOrder2 = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetOrders");
            requestOrder2.Method = "GET";
            String testOrder2 = String.Empty;
            using (HttpWebResponse responseOrder2 = (HttpWebResponse)requestOrder2.GetResponse())
            {
                Stream dataStream = responseOrder2.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testOrder2 = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

            }
            var OrderList = JsonSerializer.Deserialize<List<Order>>(testOrder2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            int orderid=OrderList.Max(a => a.OrderId);
            Product product = new Product();
           

            Console.WriteLine("OrderId:"+orderid);
            
            Console.WriteLine("UnitPrice:"+ unitprice);
            
            Console.Write("Quantity:");
            var quantity=Console.ReadLine();
            Console.Write("Discount:");
            var discount = Console.ReadLine();


            HttpWebRequest requestOrderDetails = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/AddOrderDetails?orderid=" + orderid + "&productid=" + ProductId + "&unitprice=" + unitprice + "&quantity=" + quantity + "&discount=" + discount);
            requestOrderDetails.Method = "POST";
            String testOrderDetails = String.Empty;
            using (HttpWebResponse responseOrderDetails = (HttpWebResponse)requestOrderDetails.GetResponse())
            {
                Stream dataStream = responseOrderDetails.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testOrderDetails = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

            }

        }
    }
}
