using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;
using area452.Core;
using area452.Models;
using area452.Repositorio;

namespace area452.Controllers
{
    public class TesteController : Controller
    {
        private BancoDadosContext db2 = new BancoDadosContext();
        AgendaEntities db = new AgendaEntities();

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /teste/Details/5

        public ActionResult Details(int id = 0)
        {
            tbl1 tbl1 = db.tbl1.Find(id);
            if (tbl1 == null)
            {
                return HttpNotFound();
            }
            return View(tbl1);
        }

        //
        // GET: /teste/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /teste/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl1 tbl1)
        {
            if (ModelState.IsValid)
            {
                db.tbl1.Add(tbl1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl1);
        }

        //
        // GET: /teste/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tbl1 tbl1 = db.tbl1.Find(id);
            if (tbl1 == null)
            {
                return HttpNotFound();
            }
            return View(tbl1);
        }

        //
        // POST: /teste/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl1 tbl1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl1);
        }

        //
        // GET: /teste/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tbl1 tbl1 = db.tbl1.Find(id);
            if (tbl1 == null)
            {
                return HttpNotFound();
            }
            return View(tbl1);
        }

        //
        // POST: /teste/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl1 tbl1 = db.tbl1.Find(id);
            db.tbl1.Remove(tbl1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GoogleDistance() 
        { 
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult gerarLinhas()
        {
            for (int i = 60000; i < 100000; i++)
            {
                ClienteLoc clienteLoc = new ClienteLoc()
                {
                    Nome = "Cliente " + i,
                    Endereco = "Rua " + i,
                    Telefone = "3123123" + i,
                    Email = "alguem@ja" + i + "com.br"
                };
                
                var ret = new AgendaRepositorio();

                var x = ret.InsereLinhasClientes(clienteLoc);

            }



            return View("Index");
        }

        [HttpGet]
        public ActionResult telerik()
        {
            return View();
        
        }


        [HttpGet]
        public ActionResult login()
        {
            ViewBag.resultado = ".";
            return View();

        }

        [HttpPost]
        public ActionResult checklogin(FormCollection frm)
        {
            ViewBag.resultado = "Dados inseridos com sucesso.";
            return View("login");

        }


        [HttpPost]
        public ActionResult lista(string product)
        {
          List<Countries> country = new List<Countries>();

          if (string.IsNullOrEmpty(product))
          {
              country = db2.countries.ToList();
          }
          else
          {
              country = db2.countries.Where(x => x.CountryName == product).ToList();
          } 
           
            return View(country);

        }

        
        [HttpGet]
        public ActionResult lista()
        {
            var lista = db2.countries.ToList();
            return View(lista);

        }

        public ActionResult loja()
        {
            return View();

        }
        public ActionResult treeview()
        {
            return View();

        }

        [HttpGet]
        public ActionResult cascade()
        {

            ViewBag.Cidades = new SelectList(db2.countries.ToList(), "CountryID", "CountryName");

            return View();

        }

        [HttpPost]
        public ActionResult cascade(FormCollection frm)
        {
            ViewBag.Cidades = new SelectList(db2.countries.ToList(), "CountryID", "CountryName");
            ViewBag.mensagem = "Dados armazenados com sucesso";

            return View();

        }
        // Web  metodos de cascade
        [WebMethod]
        [HttpPost]
        public JsonResult GetStates(int id)
        {
            //var statelist = db2.states.ToList();
            var statelist = db2.states.Where(x => x.CountryID == id).ToList(); ;
           
            var modelData = statelist.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.StateID.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        // Web  metodos de cascade
        [WebMethod]
        [HttpPost]
        public JsonResult GetCity(int id)
        {
            var citilist = db2.cities.Where(x => x.StateID == id).ToList();

            var modelData = citilist.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.CityID.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ActionName("subscricao")]
        public ActionResult subscricao() { return RedirectToAction("Index", "Home"); ; }



        public JsonResult GetProducts(string term) 
        {

            List<string> Paises;
            Paises = db2.countries.Where(x => x.CountryName.StartsWith(term)).Select(e => e.CountryName).Distinct().ToList();
            return Json(Paises, JsonRequestBehavior.AllowGet);
        }


        public ActionResult google()
        {
            

            return View();

        }
        public ActionResult webapi()
        {


            return View();

        }

        public ActionResult componentes()
        {


            return View();

        }

        public ActionResult GoogleDataBase()
        {


            return View();

        }

        public JsonResult GetLocs()
        {
            BaseEntidade db = new BaseEntidade();
            var bas = (from x in db.Geoloc
                       select x).ToList();

            var dados = bas.Select(x => new geoloc()
            {
                ID = x.ID,
                PlaceName = x.PlaceName,
                OpeningHours = x.OpeningHours,
                GeoLat = x.GeoLat,
                GeoLong = x.GeoLong
            });

            return Json(dados, JsonRequestBehavior.AllowGet);
        }

    }
}

//controller
//public ActionResult CustomerInfo()
//        {

//            var List = GetCustomerName();
//            ViewBag.CustomerNameID = new SelectList(List, "CustomerId", "customerName");
//            ViewBag.RegisterItems = GetAllRegisterData();
//            return View();
//        }

//public List<CustomerModel> GetCustomerName()
//        {
//            // Customer DropDown
//            using (dataDataContext _context = new dataDataContext())
//            {
//                return (from c in _context.Customers
//                        select new CustomerModel
//                        {
//                            CustomerId = c.CID,
//                            customerName = c.CustomerName
//                        }).ToList<CustomerModel>();
//            }
//        }

//Model:

// public class CustomerModel
//    {
//        public int CustomerId { get; set; }

//        [StringLength(9), Required, DisplayName("Social security number")]
//        [RegularExpression(@"\d{3}-\d\d-\d{4}", ErrorMessage = "Invalid social security number")]
//        public string customerName { get; set; }

//        public List<MyListItems> customerNameList { get; set; }
//}


