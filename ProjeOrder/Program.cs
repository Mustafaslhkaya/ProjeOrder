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

            Console.WriteLine(testCustomer);
            Console.Write("CustomerId:");
            string customerId = Console.ReadLine();

            HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44325/weatherforecast/GetEmployees");
            request2.Method = "GET";
            String testEmployee = String.Empty;
            using (HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse())
            {
                Stream dataStream = response2.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                testEmployee = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                
            }

            Console.WriteLine(testEmployee);
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

            Console.WriteLine(testProduct);
            Console.Write("ProductId:");
            string ProductId = Console.ReadLine();

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

            Console.WriteLine(testShipper);
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

            Console.WriteLine(testOrder2.Max());
            Console.Write("OrderId:");
            var orderid = Console.ReadLine();
            Console.Write("UnitPrice:");
            var unitprice=Console.ReadLine();
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
