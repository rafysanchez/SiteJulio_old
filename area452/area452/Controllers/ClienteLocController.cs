using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using area452.Core;
using area452.Models;


namespace area452.Controllers
{
    public class ClienteLocController : Controller
    {

        public ActionResult Index(string sortOrder, string CurrentSort, int? page) 
        {
            BancoDadosContext db = new BancoDadosContext();

            int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "ClienteId" : sortOrder;

            IPagedList<ClienteLoc> clienteLoc = null;

            switch (sortOrder)
            {
                case "Nome":
                    if (sortOrder.Equals(CurrentSort))
                        clienteLoc = db.ClientesLoc.OrderByDescending(m => m.Nome).ToPagedList(pageIndex, pageSize);
                    else
                        clienteLoc = db.ClientesLoc.OrderBy(m => m.Nome).ToPagedList(pageIndex, pageSize);
                    break;
                case "data_cadastro":
                    if (sortOrder.Equals(CurrentSort))
                        clienteLoc = db.ClientesLoc.OrderByDescending(m => m.data_cadastro).ToPagedList(pageIndex, pageSize);
                    else
                        clienteLoc = db.ClientesLoc.OrderBy(m => m.data_cadastro).ToPagedList(pageIndex, pageSize);
                    break;
                case "ClienteId":
                    if (sortOrder.Equals(CurrentSort))
                        clienteLoc = db.ClientesLoc.OrderByDescending(m => m.ClienteId).ToPagedList(pageIndex, pageSize);
                    else
                        clienteLoc = db.ClientesLoc.OrderBy(m => m.ClienteId).ToPagedList(pageIndex, pageSize);
                    break;
            }

            return View(clienteLoc);
        }



    }// end class
}