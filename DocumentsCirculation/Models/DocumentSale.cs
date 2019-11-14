using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentSale: Document
    {
        public int documentsaleID { get; set; }
        public string productname { get; set; }
        public int productammount_num { get; set; }
        public decimal productprice_for_one { get; set; }
        public int buyerID { get; set; }

        public List<DocumentSale> DocumentSaleList { get; set; }

        public decimal CostCount()
        {
            return this.productammount_num * this.productprice_for_one;
        }
    }
}