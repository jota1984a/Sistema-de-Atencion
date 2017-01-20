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
    public class PRIVILEGIOsController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: PRIVILEGIOs
        public ActionResult Index()
        {
            var pRIVILEGIO = db.PRIVILEGIO.Include(p => p.ROL);
            return View(pRIVILEGIO.ToList());
        }

        // GET: PRIVILEGIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIVILEGIO pRIVILEGIO = db.PRIVILEGIO.Find(id);
            if (pRIVILEGIO == null)
            {
                return HttpNotFound();
            }
            return View(pRIVILEGIO);
        }

        // GET: PRIVILEGIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL");
            return View();
        }

        // POST: PRIVILEGIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRIVILEGIO,ID_ROL,NOMBRE_PRIVILEGIO,DESCRIPCION_PRIVILEGIO")] PRIVILEGIO pRIVILEGIO)
        {
            if (ModelState.IsValid)
            {
                db.PRIVILEGIO.Add(pRIVILEGIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", pRIVILEGIO.ID_ROL);
            return View(pRIVILEGIO);
        }

        // GET: PRIVILEGIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIVILEGIO pRIVILEGIO = db.PRIVILEGIO.Find(id);
            if (pRIVILEGIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", pRIVILEGIO.ID_ROL);
            return View(pRIVILEGIO);
        }

        // POST: PRIVILEGIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRIVILEGIO,ID_ROL,NOMBRE_PRIVILEGIO,DESCRIPCION_PRIVILEGIO")] PRIVILEGIO pRIVILEGIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRIVILEGIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", pRIVILEGIO.ID_ROL);
            return View(pRIVILEGIO);
        }

        // GET: PRIVILEGIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIVILEGIO pRIVILEGIO = db.PRIVILEGIO.Find(id);
            if (pRIVILEGIO == null)
            {
                return HttpNotFound();
            }
            return View(pRIVILEGIO);
        }

        // POST: PRIVILEGIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRIVILEGIO pRIVILEGIO = db.PRIVILEGIO.Find(id);
            db.PRIVILEGIO.Remove(pRIVILEGIO);
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
