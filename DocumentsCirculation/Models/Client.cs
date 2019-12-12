using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Client
    {
        public int clientID {get; set;}

        [Display(Name = "Оффициальное имя клиента")]
        public string officialname { get; set; }

        [Display(Name = "e-mail")]
        public string email { get; set; }

        public List<Client> ClientList { get; set; }
    }
}