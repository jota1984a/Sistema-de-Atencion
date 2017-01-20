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
    public class TIEMPO_ATENCIONController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: TIEMPO_ATENCION
        public ActionResult Index()
        {
            return View(db.TIEMPO_ATENCION.ToList());
        }

        // GET: TIEMPO_ATENCION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEMPO_ATENCION tIEMPO_ATENCION = db.TIEMPO_ATENCION.Find(id);
            if (tIEMPO_ATENCION == null)
            {
                return HttpNotFound();
            }
            return View(tIEMPO_ATENCION);
        }

        // GET: TIEMPO_ATENCION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIEMPO_ATENCION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ATENCION,TIEMPO_ATENCION1,VALOR_ATENCION")] TIEMPO_ATENCION tIEMPO_ATENCION)
        {
            if (ModelState.IsValid)
            {
                db.TIEMPO_ATENCION.Add(tIEMPO_ATENCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIEMPO_ATENCION);
        }

        // GET: TIEMPO_ATENCION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEMPO_ATENCION tIEMPO_ATENCION = db.TIEMPO_ATENCION.Find(id);
            if (tIEMPO_ATENCION == null)
            {
                return HttpNotFound();
            }
            return View(tIEMPO_ATENCION);
        }

        // POST: TIEMPO_ATENCION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ATENCION,TIEMPO_ATENCION1,VALOR_ATENCION")] TIEMPO_ATENCION tIEMPO_ATENCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIEMPO_ATENCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIEMPO_ATENCION);
        }

        // GET: TIEMPO_ATENCION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEMPO_ATENCION tIEMPO_ATENCION = db.TIEMPO_ATENCION.Find(id);
            if (tIEMPO_ATENCION == null)
            {
                return HttpNotFound();
            }
            return View(tIEMPO_ATENCION);
        }

        // POST: TIEMPO_ATENCION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIEMPO_ATENCION tIEMPO_ATENCION = db.TIEMPO_ATENCION.Find(id);
            db.TIEMPO_ATENCION.Remove(tIEMPO_ATENCION);
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
