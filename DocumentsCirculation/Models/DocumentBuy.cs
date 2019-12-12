using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class DocumentBuy: Document
    {
        public int documentbuyID { get; set; }

        [Display(Name = "Название продукции")]
        public string productname { get; set; }

        [Display(Name = "Количество продукции (киллограмм)")]
        public decimal productammount_killo { get; set; }

        [Display(Name = "Цена за 1 кг")]
        public decimal productprice_for_killo { get; set; }

        [Display(Name = "ID продавца")]
        public int sellerID { get; set; }

        public List<DocumentBuy> DocumentSaleList { get; set; }

        public decimal CostCount()
        {
            return this.productammount_killo * this.productprice_for_killo;
        }
    }
}