using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API_Data_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database server started");

            ServiceHost host;

            NetTcpBinding tcp = new NetTcpBinding();

            host = new ServiceHost(typeof(DataServer));

            host.AddServiceEndpoint(typeof(IDataServer), tcp, "net.tcp://0.0.0.0:8100/DataService");
            host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            host.Close();
        }
    }
}
