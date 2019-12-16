using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Document
    {
        [Display(Name = "Номер документа")]
        public int documentID { get; set; }

        [Display(Name = "Название")]
        public string name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public DateTime creationdate { get; set; }

        [Display(Name = "IDавтора")]
        public int authorID { get; set; }

        [Display(Name = "Статус")]
        public string status { get; set; }

        [Display(Name = "Комментарий")]
        public string comment { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Хранить до")]
        public DateTime shelflife { get; set; }

        [Display(Name = "ID подписывающего")]
        public int signerID { get; set; }

        [Display(Name = "Тип")]
        public string type { get; set; }
    }
}