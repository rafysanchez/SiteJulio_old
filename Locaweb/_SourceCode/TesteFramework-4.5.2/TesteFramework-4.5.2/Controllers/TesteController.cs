using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JulioMVC.Models;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TesteFramework.Controllers
{
    public class TesteController : Controller
    {
        
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        
    }
}