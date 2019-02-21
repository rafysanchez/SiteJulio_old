using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using area452.Models;
using area452.Repositorio;


namespace area452.Controllers
{
    public class AgendaController : Controller
    {
       
        // GET: /Agenda/
        AgendaEntities db = new AgendaEntities();

        public ActionResult Index()
        {
            AgendaRepositorio agrep = new AgendaRepositorio();

            List<Agenda> agendas = agrep.GetAgendas();

            return View(agendas.ToList());
        }

        public string cert()
        {
            AgendaRepositorio agrep = new AgendaRepositorio();
            bool d = agrep.TESTE();
            if (d) { return "ok"; } else { return "notOk"; }
        }

        /// <summary>
        /// Consulta os dados de um cliente
        /// GET: /Clientes/Details/5
        /// </summary>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Casa,Cliente,Telefone,DataEntrada,DataSaida,HoraEntrada,HoraSaida")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.agenda.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenda);
        }

        /// <summary>
        /// Exibe o formulário para edição do cadastro de um cliente
        /// GET: /Clientes/Edit/5
        /// </summary>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        /// <summary>
        /// Salva os dados do formulário do cliente alterado
        /// POST: /Clientes/Edit/5
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgendaID,Casa,Cliente,Telefone,DataEntrada,DataSaida,HoraEntrada,HoraSaida")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        /// <summary>
        /// Exibe o formulário para deletar um cliente cadastrado
        /// GET: /Clientes/Delete/5
        /// </summary>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        /// <summary>
        /// Executa deleção do cliente selecionado
        /// POST: /Clientes/Delete/5
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.agenda.Find(id);
            db.agenda.Remove(agenda);
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