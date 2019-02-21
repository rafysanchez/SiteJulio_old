using System.Web.Mvc;
using TesteFramework.Core;
using TesteFramework.Models;

namespace TesteFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Aplicativo para testes de MVC.";

            return View();
        }

        public ActionResult Contact(FormCollection frm)
        {
            ViewBag.Message = "Pagina de Contato.";

            return View();
        }
        public ActionResult Tabs()
        {

            return View();
        }

        public ActionResult datepicker() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contato(FormCollection frm)
        {
            try
            {
                Contato contato = new Contato()
                {
                    Nome = frm["username"].Trim().ToUpper(),
                    Email = frm["useremail"].Trim().ToLower(),
                    Site = frm["usersite"].Trim(),
                    Comentario = frm["usermessage"].Trim()
                };
                BancoDadosContext db = new BancoDadosContext();
                db.contatos.Add(contato);
                db.SaveChanges();
                ViewBag.mensagem = "Contato Concluído.";
            }
            catch
            {
                throw;
            }



            return View("Contact");
        }

        [HttpPost, ActionName("subscricao")]
        public ActionResult subscricao(FormCollection frm) 
        { 
            return RedirectToAction("Index", "Home"); 
        }
    }
}