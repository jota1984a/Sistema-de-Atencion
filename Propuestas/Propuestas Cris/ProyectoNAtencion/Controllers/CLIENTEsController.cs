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
    public class CLIENTEsController : Controller
    {
        private NatencionEntities1 db = new NatencionEntities1();

        // GET: CLIENTEs
        public ActionResult Index()
        {
            var cLIENTE = db.CLIENTE.Include(c => c.ESTADO).Include(c => c.ROL);
            return View(cLIENTE.ToList());
        }

        // GET: CLIENTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION_ESTADO");
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL");
            return View();
        }

        // POST: CLIENTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLIENTE,ID_ESTADO,ID_ROL,NOMBRE,APPAT,APMAT,RUT,DIRECCION,TELEFONO,EMAIL,USUARIO,PASS,PREGUNTASEG1,RESPUESTASEG1,PREGUNTASEG2,RESPUESTASEG2,UCR_CLIENTE,UAC_CLIENTE,UEL_CLIENTE,FCR_CLIENTE,FAC_CLIENTE,FEL_CLIENTE")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION_ESTADO", cLIENTE.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", cLIENTE.ID_ROL);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION_ESTADO", cLIENTE.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", cLIENTE.ID_ROL);
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTE,ID_ESTADO,ID_ROL,NOMBRE,APPAT,APMAT,RUT,DIRECCION,TELEFONO,EMAIL,USUARIO,PASS,PREGUNTASEG1,RESPUESTASEG1,PREGUNTASEG2,RESPUESTASEG2,UCR_CLIENTE,UAC_CLIENTE,UEL_CLIENTE,FCR_CLIENTE,FAC_CLIENTE,FEL_CLIENTE")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "DESCRIPCION_ESTADO", cLIENTE.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", cLIENTE.ID_ROL);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            db.CLIENTE.Remove(cLIENTE);
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
