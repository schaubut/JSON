using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using RestSharp;

public class Customer
{
    public string UserId { get; set; }
    public string CustomerId { get; set; }


}

public class Root
{
    public string[] roots { get; set; }
}


namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {
         

            List<string> Tests = new List<string>();
            ArrayList customers = new ArrayList();

            JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\jons\source\repos\JSONTest\CreateEmployee-Old.json"));

            var client = new RestClient("http://dummy.restapiexample.com/where/else?key=value");

            var request = new RestRequest();

            request.Method = Method.GET;

            request.AddHeader("Accept", "application/json");

            request.Parameters.Clear();

            request.AddParameter("application/json", o1, ParameterType.RequestBody);

            var response = client.Execute(request);

            DeserializeResult results = JsonConvert.DeserializeObject<DeserializeResult>(response.Content);

            string success = results.Success;


            Console.WriteLine("Success = {0}", success);



            foreach (var cust in o1)
            {


                Tests.Add(cust.Key);
                customers.Add(cust.Value);



            }
            Console.WriteLine("=========================");
            for (int i = 0; i <= customers.Count - 1; i++)
            {
                Console.WriteLine("-------------------------------------" + Tests[i]);
                Console.WriteLine(customers[i]);

            }
        }
    }
}
