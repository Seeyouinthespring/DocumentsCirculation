using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentSale: Document
    {
        public int documentsaleID { get; set; }

        [Display(Name = "Название продукции")]
        public string productname { get; set; }

        [Display(Name = "Количество прдукции")]
        public int productammount_num { get; set; }

        [Display(Name = "Цена за 1 шт.")]
        public decimal productprice_for_one { get; set; }

        [Display(Name = "ID покупателя")]
        public int buyerID { get; set; }

        public List<DocumentSale> DocumentSaleList { get; set; }

        public decimal CostCount()
        {
            return this.productammount_num * this.productprice_for_one;
        }
    }
}