using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Natencion.Models;

namespace Natencion.Controllers
{
    public class COMUNAsController : Controller
    {
        private NatencionEntities db = new NatencionEntities();

        // GET: COMUNAs
        public ActionResult Index()
        {
            var cOMUNA = db.COMUNA.Include(c => c.CIUDAD);
            return View(cOMUNA.ToList());
        }

        // GET: COMUNAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNA cOMUNA = db.COMUNA.Find(id);
            if (cOMUNA == null)
            {
                return HttpNotFound();
            }
            return View(cOMUNA);
        }

        // GET: COMUNAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE_CIUDAD");
            return View();
        }

        // POST: COMUNAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COMUNA,ID_CIUDAD,NOMBRE_COMUNA")] COMUNA cOMUNA)
        {
            if (ModelState.IsValid)
            {
                db.COMUNA.Add(cOMUNA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE_CIUDAD", cOMUNA.ID_CIUDAD);
            return View(cOMUNA);
        }

        // GET: COMUNAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNA cOMUNA = db.COMUNA.Find(id);
            if (cOMUNA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE_CIUDAD", cOMUNA.ID_CIUDAD);
            return View(cOMUNA);
        }

        // POST: COMUNAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COMUNA,ID_CIUDAD,NOMBRE_COMUNA")] COMUNA cOMUNA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMUNA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIUDAD = new SelectList(db.CIUDAD, "ID_CIUDAD", "NOMBRE_CIUDAD", cOMUNA.ID_CIUDAD);
            return View(cOMUNA);
        }

        // GET: COMUNAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNA cOMUNA = db.COMUNA.Find(id);
            if (cOMUNA == null)
            {
                return HttpNotFound();
            }
            return View(cOMUNA);
        }

        // POST: COMUNAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMUNA cOMUNA = db.COMUNA.Find(id);
            db.COMUNA.Remove(cOMUNA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
