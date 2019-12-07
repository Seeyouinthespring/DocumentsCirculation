using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;

namespace DocumentsCirculation.Controllers
{
    public class DocSaleController : Controller
    {
        DocSaleDAO docsale = new DocSaleDAO();
        AdministrationDAO admin = new AdministrationDAO();
        
        // GET: DocSale
        public ActionResult DocSaleIndex()
        {
            return View(docsale.GetAllSales());
        }

        // GET: DocSale/Details/5
        public ActionResult DocSaleDetails(int id)
        {
            List<DocumentSale> dsList = docsale.GetAllSales();
            int pos = 0;
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                }
            return View(dsList[pos]);
        }

        // GET: DocSale/Create
        public ActionResult DocSaleCreate()
        {
            return View();
        }

        // POST: DocSale/Create
        [HttpPost]
        public ActionResult DocSaleCreate( DocumentSale ds)
        {
            try
            {
                if (docsale.AddSale(ds))
                    return RedirectToAction("DocSaleIndex");
                else return View("DocSaleCreate");
            }
            catch
            {
                return View("DocSaleCreate");
            }
        }

        // GET: DocSale/Edit/5
        public ActionResult DocSaleEdit(int id)
        {
            List<DocumentSale> dsList = docsale.GetAllSales();
            int pos = 0;
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                }
            return View(dsList[pos]);
        }

        // POST: DocSale/Edit/5
        [HttpPost]
        public ActionResult DocSaleEdit(int id, DocumentSale ds)
        {
            try
            {
                if (docsale.ChangeSale(id, ds))
                    return RedirectToAction("DocSaleIndex");
                else return View("DocSaleEdit");
            }
            catch
            {
                return View("DocSaleEdit");
            }
        }

        // GET: DocSale/Delete/5
        public ActionResult DocSaleDelete(int id)
        {
            List<DocumentSale> dsList = docsale.GetAllSales();
            int pos = 0;
            for (int i = 0; i < dsList.Count; i++)
                if (id == dsList[i].documentID)
                {
                    pos = i;
                }
            return View(dsList[pos]);
        }

        // POST: DocSale/Delete/5
        [HttpPost, ActionName("DocSaleDelete")]
        public ActionResult DocSaleDelete(int id, FormCollection collection)
        {
            try
            {
                if (admin.DropDoc(id))
                    return RedirectToAction("DocSaleIndex");
                else return View("DocSaleDelete");
            }
            catch
            {
                return View("DocSaleDelete");
            }
        }
    }
}
