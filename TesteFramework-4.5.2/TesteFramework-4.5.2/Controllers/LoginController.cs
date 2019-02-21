using System.Web.Mvc;
using TesteFramework.Models;

namespace TesteFramework.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login() 
        {
            return View();

        }


        [HttpPost]
        public ActionResult Login(Login log)
        {
            if (ModelState.IsValid)
            {
                ViewBag.mensagem = "dados chegaram OK.";
                return View(log);
            }

            return RedirectToAction("Index");
        }



    }
}