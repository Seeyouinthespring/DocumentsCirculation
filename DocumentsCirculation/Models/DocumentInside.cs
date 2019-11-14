using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentInside : Document
    {
        public int docinsideID { get; set;}
        public decimal moneydifference { get; set;}
        public int targetID { get; set; }

        public List<DocumentInside> DocumentInsedeList { get; set; }
    }
}