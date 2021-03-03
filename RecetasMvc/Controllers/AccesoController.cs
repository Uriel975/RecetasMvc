using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecetasMvc.Controllers
{
    public class AccesoController : Controller
    {
        TblUsuarioCTRL Total = new TblUsuarioCTRL();
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public int IniciarSesion()
        {
            string correo = Request.Form.Get("correo");
            string contraseña = Request.Form.Get("contraseña");

            TblUsuariosBO data = new TblUsuariosBO();

            data.Correo = correo;
            data.Contraseña = contraseña;

            try
            {
                int Y = 0;
                List<TblUsuariosBO> datos = Total.Validar(data);

                foreach (var des in datos)
                {
                    Session["ID"] = des.IDUsuario;
                    Session["Nombre"] = des.Nombre;
                    Session["Apellido"] = des.Apellido;
                    Session["Correo"] = des.Correo;
                    Session["Contraseña"] = des.Contraseña;
                    Session["Genero"] = des.Genero;
                    Session["Rol"] = des.Rol;

                }
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public ActionResult CerrarSesion()
        {
            Session["ID"] = null;
            Session["Nombre"] = null;
            Session["Apellido"] = null;
            Session["Correo"] = null;
            Session["Contraseña"] = null;
            Session["Genero"] = null;
            Session["Rol"] = null;
            return RedirectToAction("../Acceso/Login");
        }

        //
        public ActionResult RedirectRol()
        {
            if (Session["Rol"]!=null)
            {
                if (Session["Rol"].ToString() == "Administrador")
                {
                    return RedirectToAction("../Administrativo/AdminView");
                }
                else if (Session["Rol"].ToString() == "Cliente")
                {
                    return RedirectToAction("../Administrativo/ClientView");
                }
            }else
                return RedirectToAction("../Acceso/Login");
            return View();
        }
    }
}