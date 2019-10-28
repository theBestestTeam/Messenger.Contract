using Messenger.Contract.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessangerApp.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //Activating the messages through the services
            var uris = new Uri[1];
            string address = "net.tcp://localhost:6565/MessageService";
            uris[0] = new Uri(address);
            IMessageService service = new MessageService();

            ServiceHost host = new ServiceHost(service, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, String.Empty);
            host.Opened += HostOnOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOnOpened(object sender, EventArgs e)
        {
            Console.WriteLine("TCP Service started");
        }
    }
}
