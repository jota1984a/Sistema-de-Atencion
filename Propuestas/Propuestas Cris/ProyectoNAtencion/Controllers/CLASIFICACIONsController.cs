using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoNAtencion.Models;

namespace ProyectoNAtencion.Controllers
{
    public class CLASIFICACIONsController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: CLASIFICACIONs
        public ActionResult Index()
        {
            return View(db.CLASIFICACION.ToList());
        }

        // GET: CLASIFICACIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLASIFICACIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLASIFICACION,NUMERO,HORA,NOMBRE")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.CLASIFICACION.Add(cLASIFICACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLASIFICACION,NUMERO,HORA,NOMBRE")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASIFICACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASIFICACION cLASIFICACION = db.CLASIFICACION.Find(id);
            db.CLASIFICACION.Remove(cLASIFICACION);
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
