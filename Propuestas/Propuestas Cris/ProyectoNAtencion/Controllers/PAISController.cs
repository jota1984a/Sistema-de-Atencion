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
    public class PAISController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: PAIS
        public ActionResult Index()
        {
            return View(db.PAIS.ToList());
        }

        // GET: PAIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAIS.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // GET: PAIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAIS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAIS,NOMBRE_PAIS")] PAIS pAIS)
        {
            if (ModelState.IsValid)
            {
                db.PAIS.Add(pAIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAIS);
        }

        // GET: PAIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAIS.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // POST: PAIS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAIS,NOMBRE_PAIS")] PAIS pAIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAIS);
        }

        // GET: PAIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAIS.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // POST: PAIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAIS pAIS = db.PAIS.Find(id);
            db.PAIS.Remove(pAIS);
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
