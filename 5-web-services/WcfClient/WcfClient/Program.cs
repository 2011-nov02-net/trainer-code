using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.MyWcfService;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeType result;
            using (var client = new Service1Client())
            {
                result = client.GetDataUsingDataContract(new CompositeType { append = true, StringValue = "adsf" });
            }
            Console.WriteLine(result.StringValue);
        }
    }
}
