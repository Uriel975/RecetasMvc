using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Web.Mvc;

namespace RecetasMvc.Controllers
{
    public class RecetaController : Controller
    {

        // GET: Receta
        TblRecetaCTRL Receta = new TblRecetaCTRL();
        TblCategoriasCTRL Categoria = new TblCategoriasCTRL();

        [HttpGet]
        public ActionResult RecetasEdit(int id=0)
        {
            //Receta receta1 = new Receta();
            return View();
        }

        public ActionResult Ver()
        {
            if (Session["ID"] != null)
            {
                if (Session["Rol"].ToString() == "Administrador")
                {
                    ViewBag.RecetaList = Receta.TraerReceta();
                    return View();
                }
                else
                    return RedirectToAction("../Acceso/Login");
            }else
               return RedirectToAction("../Acceso/Login");

        }

        public ActionResult Agregar()
        {
            if (Session["ID"] != null)
            {
                if (Session["Rol"].ToString() == "Administrador" || Session["Rol"].ToString() =="Cliente")
                {
                    ViewBag.ListCategoria = Categoria.Traer();
                    return View();
                }
                else
                    return RedirectToAction("../Acceso/Login");
            }
            else
                return RedirectToAction("../Acceso/Login");
        }

        public int AgregarReceta()
        {
            TblRecetaBO Actualizacion = new TblRecetaBO();
            string receta = Request.Form.Get("RECETA");
            string tiempo = Request.Form.Get("TIEMPO");
            string ingredientes = Request.Form.Get("INGREDIENTES");
            string preparacion = Request.Form.Get("PREPARACION");
            //int cat = Request.Form.Get("cat");

            int FkUsuario = int.Parse(Session["ID"].ToString()) ; 
            
            Actualizacion.RECETA = receta;
            Actualizacion.TIEMPO = tiempo;
            Actualizacion.INGREDIENTES = ingredientes;
            Actualizacion.PREPARACION = preparacion;
            Actualizacion.FKUSUARIO = FkUsuario;
            //Actualizacion

            try
            {
                int X = 0;
                X = Receta.Agregar(Actualizacion);
                return X;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public int EliminarReceta()
        {
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int Y = 0;
                Y = Receta.Eliminar(id);
                return Y;
            }
            catch
            {
                return 0;
            }

        }

        public int EditaReceta()
        {
            int id = int.Parse(Request.Form.Get("id"));
            string receta = Request.Form.Get("receta");
            string tiempo = Request.Form.Get("tiempo");
            string ingredientes = Request.Form.Get("ingredientes");
            string preparacion = Request.Form.Get("preparacion");

            TblRecetaBO data = new TblRecetaBO();

            data.ID_RECETA = id;
            data.RECETA = receta;
            data.TIEMPO = tiempo;
            data.INGREDIENTES = ingredientes;
            data.PREPARACION = preparacion;

            try
            {
                int Y = 0;
                Y = Receta.Actualizar(data);
                return Y;
            }
            catch
            {
                return 0;
            }
        }
    }
}