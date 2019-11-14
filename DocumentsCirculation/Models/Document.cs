using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Document
    {
        public int documentID { get; set; }
        public string name { get; set; }
        public DateTime creationdate { get; set; }
        public int authorID { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public DateTime shelflife { get; set; }
        public int signerID { get; set; }
        public string type { get; set; }
    }
}