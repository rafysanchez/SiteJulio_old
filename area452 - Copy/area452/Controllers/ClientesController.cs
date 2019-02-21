using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Services;
using area452.Core;
using area452.Models;

namespace area452.Controllers
{
    public class ClientesController : Controller
    {
        private BancoDadosContext db = new BancoDadosContext();

        /// <summary>
        /// Página inicial
        /// GET: /Clientes
        /// </summary>
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        /// <summary>
        /// Consulta os dados de um cliente
        /// GET: /Clientes/Details/5
        /// </summary>
        /// 
        [WebMethod]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        /// <summary>
        /// Exibe o formulário para cadastro de um novo cliente
        /// GET: /Clientes/Create
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Salva os dados do formulário do novo cliente
        /// POST: /Clientes/Create
        /// </summary>
        [WebMethod]
        [HttpPost]
        public ActionResult CreateData(FormCollection dados, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        /// <summary>
        /// Exibe o formulário para edição do cadastro de um cliente
        /// GET: /Clientes/Edit/5
        /// </summary>
        /// 
        [WebMethod]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        /// <summary>
        /// Salva os dados do formulário do cliente alterado
        /// POST: /Clientes/Edit/5
        /// </summary>
        /// 
        [WebMethod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nome,Endereco,Telefone,Email,DataCadastro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        /// <summary>
        /// Exibe o formulário para deletar um cliente cadastrado
        /// GET: /Clientes/Delete/5
        /// </summary>
        /// 
        [WebMethod]
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        /// <summary>
        /// Executa deleção do cliente selecionado
        /// POST: /Clientes/Delete/5
        /// </summary>
        /// 
        [WebMethod]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Utilizado para fechar a conexão com o banco de dados
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
