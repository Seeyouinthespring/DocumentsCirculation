using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;

namespace DocumentsCirculation.Controllers
{
    public class ClientController : Controller
    {
        ClientDAO cli = new ClientDAO();
        // GET: Client
        public ActionResult ClientIndex()
        {
            return View(cli.GetAllClients());
        }

        // GET: Client/Details/5
        public ActionResult ClientDetails(int id)
        {
            List<Client> cliList = cli.GetAllClients();
            int pos = 0;
            for (int i = 0; i < cliList.Count; i++)
                if (id == cliList[i].clientID)
                {
                    pos = i;
                }
            return View(cliList[pos]);
        }

        // GET: Client/Create
        public ActionResult ClientCreate()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult ClientCreate(Client c)
        {
            try
            {
                if (cli.AddClient(c))
                    return RedirectToAction("ClientIndex");
                else return View("ClientCreate");
            }
            catch
            {
                return View("ClientCreate");
            }
        }

        // GET: Client/Edit/5
        public ActionResult ClientEdit(int id)
        {
            List<Client> cliList = cli.GetAllClients();
            int pos = 0;
            for (int i = 0; i < cliList.Count; i++)
                if (id == cliList[i].clientID)
                {
                    pos = i;
                }
            return View(cliList[pos]);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult ClientEdit(int id, Client c)
        {
            try
            {
                if (cli.ChangeClient(id,c))
                    return RedirectToAction("ClientIndex");
                else return View("ClientEdit");
            }
            catch
            {
                return View("ClientEdit");
            }
        }

        // GET: Client/Delete/5
        public ActionResult ClientDelete(int id)
        {
            List<Client> cliList = cli.GetAllClients();
            int pos = 0;
            for (int i = 0; i < cliList.Count; i++)
                if (id == cliList[i].clientID)
                {
                    pos = i;
                }
            return View(cliList[pos]);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult ClientDelete(int id, FormCollection collection)
        {
            try
            {
                if (cli.DropClient(id))
                    return RedirectToAction("ClientIndex");
                else return View("ClientDelete");
            }
            catch
            {
                return View("ClientDelete");
            }
        }
    }
}
