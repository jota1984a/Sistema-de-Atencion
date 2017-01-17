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
    public class LoginController : Controller
    {
        NatencionEntities db = new NatencionEntities();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["sesion"] != null)
            {
                try
                {
                    EMPLEADO e = (EMPLEADO)Session["sesion"];
                    return View("LoginEmpleado");
                }
                catch (Exception)
                {
                    try
                    {
                        CLIENTE c = (CLIENTE)Session["sesion"];
                        return View("LoginCliente");//Debe ir al Json
                    }
                    catch (Exception)
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoginGenerico(string user, string pass)
        {
            CLIENTE c = db.CLIENTE.SingleOrDefault(x => x.USUARIO == user && x.PASS == pass);

            if (c != null)
            {
                Session["usuario"] = c.USUARIO;
                Session["sesion"] = c;
                return View("LoginCliente");
            }

            EMPLEADO e = db.EMPLEADO.SingleOrDefault(x => x.USUARIO_EMPLEADO == user && x.PASS_EMPLEADO == pass);
            if (e != null)
            {
                Session["usuario"] = e.NOMBRE_EMPLEADO;
                Session["sesion"] = e;
                return View("LoginEmpleado");
            }
            else
            {
                ViewData["ErrorLoginC"] = "Usuario y / o Contraseña Incorrectos";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult LoginCliente(string user, string pass)
        {
            return View("Index");

        }
        // GET: LOGINCLIENTE
        public ActionResult LoginCliente()
        {
            if (Session["sesion"] != null)
            {
                return View(db.TIEMPO_ATENCION.ToList()); //RETORNAR JSON
            }
            else
            {
                ViewData["ErrorLoginC"] = "Error de autentificación";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult LoginEmpleado(string user, string pass)
        {
            return View();
        }

        // GET: LOGINEMPLEADO   
        public ActionResult LoginEmpleado()
        {
            if (Session["sesion"] != null)
            {
                try
                {
                    EMPLEADO e = (EMPLEADO)Session["sesion"];
                }
                catch (Exception)
                {
                    ViewData["ErrorLoginE"] = "Error de autentificación";
                    return View("Index");
                }

                return View();
            }
            else
            {
                ViewData["ErrorLoginE"] = "Error de autentificación";
                return View("Index");
            }
        }

        public ActionResult Cerrar()
        {
            Session["usuario"] = null;
            Session["sesion"] = null;
            return Redirect("/Home/Index");
        }
      }
    }
    

