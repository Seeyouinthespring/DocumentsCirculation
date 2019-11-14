using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentBuy: Document
    {
        public int documrntbuyID { get; set; }
        public string productname { get; set; }
        public decimal productammount_killo { get; set; }
        public decimal productprice_for_killo { get; set; }
        public int sellerID { get; set; }

        public List<DocumentBuy> DocumentSaleList { get; set; }

        public decimal CostCount()
        {
            return this.productammount_killo * this.productprice_for_killo;
        }
    }
}