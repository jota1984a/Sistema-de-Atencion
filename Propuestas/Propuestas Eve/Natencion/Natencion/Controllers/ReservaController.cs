using Natencion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Natencion.Controllers
{
    public class ReservaController : Controller
    {
        //Conexión a la Base de Datos de Libros 

        private NatencionEntities db = new NatencionEntities();

        // GET: Libro
        public ActionResult Index()
        {
            return View();
        }

        //Creación ActionResult(retornará una vista) que será servicio: JsonResult (no necesita vista)

        public JsonResult ObtenerNumeroReserva(int id)
        {

            //Devolver una reserva la vista desde la Base de datos.

            RESERVA r = db.RESERVA.SingleOrDefault(x => x.ID_ATENCION == id);

            //Se necesita devolver un Json, no una vista.
            return Json(r, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]

        public JsonResult ObtenerListaReserva()
        {
            //Devolver las reservas de la Base de datos.

            List<RESERVA> r = db.RESERVA.ToList();

            //Se necesita devolver un Json, no una vista.
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        //Debe ser capaz de recibir Id y Nombres.

        public JsonResult ObtenerReserva(RESERVA r)//string id, string nombre)
        {
            //Se puede desde aquí agregar RESERVA a la base desde consola.
            db.RESERVA.Add(r);
            db.SaveChanges();
            return Json("Se ha gregado la reserva");
        }
    }
}