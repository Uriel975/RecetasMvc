using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RecetasMvc.Controllers
{
    public class UsuariosController : Controller
    {
        TblUsuarioCTRL Total = new TblUsuarioCTRL();
        // GET: Usuarios
        public ActionResult Ver()
        {
            if (Session["ID"] != null)
            {
                if (Session["Rol"].ToString() == "Administrador")
                {
                    ViewBag.UsuarioLista = Total.Traer();
                    return View();
                }
                else
                    return RedirectToAction("../Acceso/Login");
            }
            else
                return RedirectToAction("../Acceso/Login");

            
        }
        public ActionResult AgregarUsuario()
        {
            if (Session["ID"] != null)
            {
                if (Session["Rol"].ToString() == "Administrador")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Acceso/Login");
            }
            else
                return RedirectToAction("../Acceso/Login");
        }

        //Agregar
        public int New()
        {
            TblUsuariosBO Actualizacion = new TblUsuariosBO();
            string nombre = Request.Form.Get("Nombre");
            string apellido = Request.Form.Get("Apellido");
            string genero = Request.Form.Get("Genero");
            string correo = Request.Form.Get("Correo");
            string contraseña = Request.Form.Get("Contraseña");
            string rol = Request.Form.Get("Rol");

            Actualizacion.Nombre = nombre;
            Actualizacion.Apellido = apellido;
            Actualizacion.Genero = genero;
            Actualizacion.Correo = correo;
            Actualizacion.Contraseña = contraseña;
            Actualizacion.Rol = rol;

            try
            {
                int X = 0;
                X = Total.Agregar(Actualizacion);
                return X;
            }
            catch(Exception ex)
            {
                return 0;
            }
                
        }
        //eliminar
        public int Eliminar()
        {
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int Y = 0;
                Y = Total.Eliminar(id);
                return Y;
            }
            catch
            {
                return 0;
            }
            
        }
        //editar
        public int EditarUsuario()
        {
            int id = int.Parse(Request.Form.Get("id"));
            string nombre = Request.Form.Get("nombre");
            string apellido = Request.Form.Get("apellido");
            string contraseña = Request.Form.Get("contraseña");
            string correo = Request.Form.Get("correo");

            TblUsuariosBO data = new TblUsuariosBO();

            data.IDUsuario = id;
            data.Nombre = nombre;
            data.Apellido = apellido;
            data.Contraseña = contraseña;
            data.Correo = correo;

            try
            {
                int Y = 0;
                Y = Total.Actualizar(data);
                return Y;
            }
            catch
            {
                return 0;
            }
        }

        
    }
}