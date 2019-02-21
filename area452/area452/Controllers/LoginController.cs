using System.Web.Mvc;
using area452.Models;

namespace area452.Controllers
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