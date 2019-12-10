using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentsCirculation.Controllers
{
    public class AdministrationController : Controller
    {
        static Document doc = new Document();
        static DocBuyDAO docbuy = new DocBuyDAO();
        static DocSaleDAO docsale = new DocSaleDAO();
        static DocReportDAO docreport = new DocReportDAO();
        static DocInsideDAO docinside = new DocInsideDAO();
        AdministrationDAO admin = new AdministrationDAO();
        List<DocumentBuy> dbList = docbuy.GetAllBuys();
        List<DocumentSale> dsList = docsale.GetAllSales();
        List<DocumentReport> drList = docreport.GetAllReports();
        List<DocumentInside> diList = docinside.GetAllInsides();

        //GET
        public ActionResult SendForSign(int id)
        {
            
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult SendForSign(int id, FormCollection collection)
        {
            try
            {
                if (admin.SendForSign(id))
                    return RedirectToAction("AllIndex");
                else return View("Mistake");
            }
            catch
            {
                return View("Mistake");
            }
        }

        //GET
        public ActionResult Sign(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Sign(int id, FormCollection collection)
        {
            try
            {
                if (admin.Sign(id))
                    return RedirectToAction("SignSuccess");
                else return View("Mistake");
            }
            catch
            {
                return View("Mistake");
            }
        }

        //POST
        [HttpPost]
        public ActionResult SendForChange(int id)
        {
            try
            {
                return RedirectToAction("WriteComment");
            }
            catch
            {
                return View("Mistake");
            }
        }

        public ActionResult SendForDrop(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult SendForDrop(int id, FormCollection collection)
        {
            try
            {
                if (admin.SendForDrop(id))
                    return RedirectToAction("AllIndex");
                else return View("Mistake");
            }
            catch
            {
                return View("Mistake");
            }
        }


        // GET: Administration
        public ActionResult AllIndex()
        {
            return View(admin.GetAll());
        }

        //Get 
        public ActionResult WriteComment(int id)
        {
            List<Document> dList = admin.GetAll();
            int pos = 0;
            for (int i = 0; i < dList.Count; i++)
                if (id == dList[i].documentID)
                {
                    pos = i;
                }
            return View(dList[pos]);
        }

        //Post
        [HttpPost]
        public ActionResult WriteComment(int id, Document d)
        {
            try
            {
                if (admin.SendForChange(id,d))
                    return RedirectToAction("AllIndex");
                else return View("Mistake");
            }
            catch
            {
                return View("Mistake");
            }
        }
    }
}
