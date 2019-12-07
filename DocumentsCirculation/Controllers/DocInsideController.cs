using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentsCirculation.Controllers
{
    public class DocInsideController : Controller
    {
        DocInsideDAO docinside = new DocInsideDAO();
        AdministrationDAO admin = new AdministrationDAO();
        // GET: DocInside
        public ActionResult DocInsideIndex()
        {
            return View(docinside.GetAllInsides());
        }

        // GET: DocInside/Details/5
        public ActionResult DocInsideDetails(int id)
        {
            List<DocumentInside> diList = docinside.GetAllInsides();
            int pos = 0;
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                }
            return View(diList[pos]);
        }

        // GET: DocInside/Create
        public ActionResult DocInsideCreate()
        {
            return View();
        }

        // POST: DocInside/Create
        [HttpPost]
        public ActionResult DocInsideCreate(DocumentInside di)
        {
            try
            {
                if (docinside.AddInside(di))
                    return RedirectToAction("DocInsideIndex");
                else return View("DocInsideCreate");
            }
            catch
            {
                return View("DocInsideCreate");
            }
        }

        // GET: DocInside/Edit/5
        public ActionResult DocInsideEdit(int id)
        {
            List<DocumentInside> diList = docinside.GetAllInsides();
            int pos = 0;
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                }
            return View(diList[pos]);
        }

        // POST: DocInside/Edit/5
        [HttpPost]
        public ActionResult DocInsideEdit(int id, DocumentInside di)
        {
            try
            {
                if (docinside.ChangeInside(id,di))
                    return RedirectToAction("DocInsideIndex");
                else return View("DocInsideEdit");
            }
            catch
            {
                return View("DocInsideEdit");
            }
        }

        // GET: DocInside/Delete/5
        public ActionResult DocInsideDelete(int id)
        {
            List<DocumentInside> diList = docinside.GetAllInsides();
            int pos = 0;
            for (int i = 0; i < diList.Count; i++)
                if (id == diList[i].documentID)
                {
                    pos = i;
                }
            return View(diList[pos]);
        }

        // POST: DocInside/Delete/5
        [HttpPost]
        public ActionResult DocInsideDelete(int id, FormCollection collection)
        {
            try
            {
                if (admin.DropDoc(id))
                    return RedirectToAction("DocInsideIndex");
                else return View("DocInsideDelete");
            }
            catch
            {
                return View("DocInsideDelete");
            }
        }
    }
}
