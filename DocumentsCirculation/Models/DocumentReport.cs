using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentReport: Document
    {
        public int documentreportID { get; set; }
        [Display(Name = "Дата начала подсчета статистики")]
        public DateTime startdate { get; set; }

        [Display(Name = "Дата конца подсчета статистики")]
        public DateTime enddate { get; set; }

        [Display(Name = "Статистика")]
        public string stats { get; set; }

        public List<DocumentReport> DocumentReportList { get; set; }
    }
}