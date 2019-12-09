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
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                    return View(dbList[pos]);
                }
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                    return View(dsList[pos]);
                }
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                    return View(drList[pos]);
                }
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                    return View(diList[pos]);
                }
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
                else return View("SendForSign");
            }
            catch
            {
                return View("SendForSign");
            }
        }

        //GET
        public ActionResult Sign(int id)
        {
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                    return View(dbList[pos]);
                }
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                    return View(dsList[pos]);
                }
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                    return View(drList[pos]);
                }
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                    return View(diList[pos]);
                }
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Sign(int id, FormCollection collection)
        {
            try
            {
                if (admin.Sign(id))
                    return RedirectToAction("AllIndex");
                else return View("Sign");
            }
            catch
            {
                return View("Sign");
            }
        }

        //POST
        [HttpPost]
        public ActionResult SendForChange(int id, string comment)
        {
            try
            {
                if (admin.SendForChange(id,comment))
                    return RedirectToAction("AllIndex");
                else return View("SSendForChange");
            }
            catch
            {
                return View("SendForChange");
            }
        }

        public ActionResult SendForDrop(int id)
        {
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                    return View(dbList[pos]);
                }
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                    return View(dsList[pos]);
                }
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                    return View(drList[pos]);
                }
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                    return View(diList[pos]);
                }
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
                else return View("SendForDrop");
            }
            catch
            {
                return View("SendForDrop");
            }
        }


        // GET: Administration
        public ActionResult AllIndex()
        {
            return View(admin.GetAll());
        }
    }
}
