using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;

namespace DocumentsCirculation.Controllers
{
    public class WorkerController : Controller
    {
        WorkerDAO workerDAO = new WorkerDAO();
        // GET: Worker
        public ActionResult WorkerIndex()
        {
            return View(workerDAO.GetAllWorkers());
        }

        // GET: Worker/Details/5
        public ActionResult WorkerDetails(int id)
        {
            List<Worker> workerList = workerDAO.GetAllWorkers();
            int pos = 0;
            for (int i = 0; i < workerList.Count; i++)
                if (id == workerList[i].workerID)
                {
                    pos = i;
                }
            return View(workerList[pos]);
        }

        // GET: Worker/Create
        public ActionResult WorkerCreate()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        public ActionResult WorkerCreate(Worker w)
        {
            try
            {
                if (workerDAO.AddWorker(w))
                    return RedirectToAction("WorkerIndex");
                else return View("WorkerCreate");
            }
            catch
            {
                return View("WorkerCreate");
            }
        }

        // GET: Worker/Edit/5
        public ActionResult WorkerEdit(int id)
        {
            List<Worker> workerList = workerDAO.GetAllWorkers();
            int pos = 0;
            for (int i = 0; i < workerList.Count; i++)
                if (id == workerList[i].workerID)
                {
                    pos = i;
                }
            return View(workerList[pos]);
        }

        // POST: Worker/Edit/5
        [HttpPost]
        public ActionResult WorkerEdit(int id, Worker w)
        {
            try
            {
                if (workerDAO.ChangeWorker(id,w))
                    return RedirectToAction("WorkerIndex");
                else return View("WorkerEdit");
            }
            catch
            {
                return View("WorkerEdit");
            }
        }

        // GET: Worker/Delete/5
        public ActionResult WorkerDelete(int id)
        {
            List<Worker> workerList = workerDAO.GetAllWorkers();
            int pos = 0;
            for (int i = 0; i < workerList.Count; i++)
                if (id == workerList[i].workerID)
                {
                    pos = i;
                }
            return View(workerList[pos]);
        }

        // POST: Worker/Delete/5
        [HttpPost]
        public ActionResult WorkerDelete(int id, FormCollection collection)
        {
            try
            {
                if (workerDAO.DropWorker(id))
                    return RedirectToAction("WorkerIndex");
                else return View("WorkerDelete");
            }
            catch
            {
                return View("WorkerDelete");
            }
        }
    }
}
