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
    public class SUCURSALsController : Controller
    {
        private NatencionEntities db = new NatencionEntities();

        // GET: SUCURSALs
        public ActionResult Index()
        {
            var sUCURSAL = db.SUCURSAL.Include(s => s.CLASIFICACION).Include(s => s.EMPRESA);
            return View(sUCURSAL.ToList());
        }

        // GET: SUCURSALs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NUMERO");
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA, "ID_EMPRESA", "NOMBRE_EMPRESA");
            return View();
        }

        // POST: SUCURSALs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,ID_CLASIFICACION,ID_EMPRESA,NOMBRE_SUCURSAL,HORA_INICIO,HORA_TERMINO,LATITUD_SUCURSAL,LONGITUD_SUCURSAL,PRECISION_SUCURSAL,UCR_SUCURSAL,UAC_SUCURSAL,UEL_SUCURSAL,FCR_SUCURSAL,FAC_SUCURSAL,FEL_SUCURSAL")] SUCURSAL sUCURSAL)
        {
            if (ModelState.IsValid)
            {
                db.SUCURSAL.Add(sUCURSAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NUMERO", sUCURSAL.ID_CLASIFICACION);
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA, "ID_EMPRESA", "NOMBRE_EMPRESA", sUCURSAL.ID_EMPRESA);
            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NUMERO", sUCURSAL.ID_CLASIFICACION);
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA, "ID_EMPRESA", "NOMBRE_EMPRESA", sUCURSAL.ID_EMPRESA);
            return View(sUCURSAL);
        }

        // POST: SUCURSALs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,ID_CLASIFICACION,ID_EMPRESA,NOMBRE_SUCURSAL,HORA_INICIO,HORA_TERMINO,LATITUD_SUCURSAL,LONGITUD_SUCURSAL,PRECISION_SUCURSAL,UCR_SUCURSAL,UAC_SUCURSAL,UEL_SUCURSAL,FCR_SUCURSAL,FAC_SUCURSAL,FEL_SUCURSAL")] SUCURSAL sUCURSAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUCURSAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLASIFICACION = new SelectList(db.CLASIFICACION, "ID_CLASIFICACION", "NUMERO", sUCURSAL.ID_CLASIFICACION);
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA, "ID_EMPRESA", "NOMBRE_EMPRESA", sUCURSAL.ID_EMPRESA);
            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL);
        }

        // POST: SUCURSALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            db.SUCURSAL.Remove(sUCURSAL);
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
