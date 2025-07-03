using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Entites.Concrete
{
    internal class Client
    {
        public string Ip { get; set; }
        public int Port { get; set; }

        public Client(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
    }
}
