using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Client
    {
        public int clientID {get; set;}
        public string officialname { get; set; }
        public string email { get; set; }

        public List<Client> ClientList { get; set; }
    }
}