﻿using System;
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
    public class EMPRESAsController : Controller
    {
        private NatencionEntities db = new NatencionEntities();

        // GET: EMPRESAs
        public ActionResult Index()
        {
            var eMPRESA = db.EMPRESA.Include(e => e.COMUNA);
            return View(eMPRESA.ToList());
        }

        // GET: EMPRESAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA");
            return View();
        }

        // POST: EMPRESAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPRESA,ID_COMUNA,NOMBRE_EMPRESA,RUT_EMPRESA,DIRECCION_EMPRESA,RUBRO_EMPRESA,GIRO_EMPRESA,UCR_EMPRESA,CAC_EMPRESA,UEL_EMPRESA,FCR_EMPRESA,FAC_EMPRESA,FEL_EMPRESA")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(eMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", eMPRESA.ID_COMUNA);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", eMPRESA.ID_COMUNA);
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPRESA,ID_COMUNA,NOMBRE_EMPRESA,RUT_EMPRESA,DIRECCION_EMPRESA,RUBRO_EMPRESA,GIRO_EMPRESA,UCR_EMPRESA,CAC_EMPRESA,UEL_EMPRESA,FCR_EMPRESA,FAC_EMPRESA,FEL_EMPRESA")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", eMPRESA.ID_COMUNA);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            db.EMPRESA.Remove(eMPRESA);
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
