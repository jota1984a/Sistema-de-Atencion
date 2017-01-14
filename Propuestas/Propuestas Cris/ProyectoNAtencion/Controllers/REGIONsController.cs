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
    public class REGIONsController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: REGIONs
        public ActionResult Index()
        {
            var rEGION = db.REGION.Include(r => r.PAIS);
            return View(rEGION.ToList());
        }

        // GET: REGIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            return View(rEGION);
        }

        // GET: REGIONs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE_PAIS");
            return View();
        }

        // POST: REGIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REGION,ID_PAIS,NOMBRE_REGION")] REGION rEGION)
        {
            if (ModelState.IsValid)
            {
                db.REGION.Add(rEGION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE_PAIS", rEGION.ID_PAIS);
            return View(rEGION);
        }

        // GET: REGIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE_PAIS", rEGION.ID_PAIS);
            return View(rEGION);
        }

        // POST: REGIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REGION,ID_PAIS,NOMBRE_REGION")] REGION rEGION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAIS, "ID_PAIS", "NOMBRE_PAIS", rEGION.ID_PAIS);
            return View(rEGION);
        }

        // GET: REGIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            return View(rEGION);
        }

        // POST: REGIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REGION rEGION = db.REGION.Find(id);
            db.REGION.Remove(rEGION);
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
