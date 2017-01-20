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
    public class RESERVAsController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: RESERVAs
        public ActionResult Index()
        {
            var rESERVA = db.RESERVA.Include(r => r.CLIENTE).Include(r => r.TIEMPO_ATENCION).Include(r => r.SUCURSAL);
            return View(rESERVA.ToList());
        }

        // GET: RESERVAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // GET: RESERVAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE");
            ViewBag.ID_ATENCION = new SelectList(db.TIEMPO_ATENCION, "ID_ATENCION", "ID_ATENCION");
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE_SUCURSAL");
            return View();
        }

        // POST: RESERVAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RESERVA,ID_SUCURSAL,ID_CLIENTE,ID_ATENCION,TIPO_RESERVA,HORA_RESERVA")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.RESERVA.Add(rESERVA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE", rESERVA.ID_CLIENTE);
            ViewBag.ID_ATENCION = new SelectList(db.TIEMPO_ATENCION, "ID_ATENCION", "ID_ATENCION", rESERVA.ID_ATENCION);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE_SUCURSAL", rESERVA.ID_SUCURSAL);
            return View(rESERVA);
        }

        // GET: RESERVAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE", rESERVA.ID_CLIENTE);
            ViewBag.ID_ATENCION = new SelectList(db.TIEMPO_ATENCION, "ID_ATENCION", "ID_ATENCION", rESERVA.ID_ATENCION);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE_SUCURSAL", rESERVA.ID_SUCURSAL);
            return View(rESERVA);
        }

        // POST: RESERVAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RESERVA,ID_SUCURSAL,ID_CLIENTE,ID_ATENCION,TIPO_RESERVA,HORA_RESERVA")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE", rESERVA.ID_CLIENTE);
            ViewBag.ID_ATENCION = new SelectList(db.TIEMPO_ATENCION, "ID_ATENCION", "ID_ATENCION", rESERVA.ID_ATENCION);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE_SUCURSAL", rESERVA.ID_SUCURSAL);
            return View(rESERVA);
        }

        // GET: RESERVAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // POST: RESERVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVA rESERVA = db.RESERVA.Find(id);
            db.RESERVA.Remove(rESERVA);
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
