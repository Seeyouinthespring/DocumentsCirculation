using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentInside : Document
    {
        public int docinsideID { get; set;}

        [Display(Name = "Разница в деньгах")]
        public int moneydifference { get; set;}

        [Display(Name = "ID рабочего")]
        public int targetID { get; set; }

        public List<DocumentInside> DocumentInsedeList { get; set; }
        public string toString()
        {
            return "Название: " + name + " Дата создания: " + creationdate + " ID автора: " + authorID + " Хранить до: " +shelflife + 
                " ID подписывающего: " + signerID+" Разница в деньгах: "+moneydifference+" ID рабочего: "+targetID;
        }
    }
}