﻿using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentsCirculation.Controllers
{
    public class DocBuyController : Controller
    {
        DocBuyDAO docbuy = new DocBuyDAO();
        AdministrationDAO admin = new AdministrationDAO();
        
        // GET: DocBuy
        public ActionResult DocBuyIndex()
        {
            return View(docbuy.GetAllBuys());
        }

        // GET: DocBuy/Details/5
        public ActionResult DocBuyDetails(int id)
        {
            List<DocumentBuy> dbList = docbuy.GetAllBuys();
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                }
            return View(dbList[pos]);
        }

        // GET: DocBuy/Create
        public ActionResult DocBuyCreate()
        {
            return View();
        }

        // POST: DocBuy/Create
        [HttpPost]
        public ActionResult DocBuyCreate(DocumentBuy db)
        {
            try
            {
                if (docbuy.AddBuy(db))
                    return RedirectToAction("DocBuyIndex");
                else return View("DocBuyCreate");
            }
            catch
            {
                return View("DocBuyCreate");
            }
        }

        // GET: DocBuy/Edit/5
        public ActionResult DocBuyEdit(int id)
        {
            List<DocumentBuy> dbList = docbuy.GetAllBuys();
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                }
            return View(dbList[pos]);
        }

        // POST: DocBuy/Edit/5
        [HttpPost]
        public ActionResult DocBuyEdit(int id, DocumentBuy db)
        {
            try
            {
                if (docbuy.ChangeBuy(id,db))
                    return RedirectToAction("DocBuyIndex");
                else return View("DocBuyEdit");
            }
            catch
            {
                return View("DocBuyEdit");
            }
        }

        // GET: DocBuy/Delete/5
        public ActionResult DocBuyDelete(int id)
        {
            List<DocumentBuy> dbList = docbuy.GetAllBuys();
            int pos = 0;
            for (int i = 0; i < dbList.Count; i++)
                if (id == dbList[i].documentID)
                {
                    pos = i;
                }
            return View(dbList[pos]);
        }

        // POST: DocBuy/Delete/5
        [HttpPost]
        public ActionResult DocBuyDelete(int id, FormCollection collection)
        {
            try
            {
                if (admin.DropDoc(id))
                    return RedirectToAction("DocBuyIndex");
                else return View("DocBuyDelete");
            }
            catch
            {
                return View("DocBuyDelete");
            }
        }
    }
}