using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentReport: Document
    {
        public int documentreportID { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string stats { get; set; }

        public List<DocumentReport> DocumentReportList { get; set; }
    }
}