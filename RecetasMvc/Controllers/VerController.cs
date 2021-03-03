using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecetasMvc.Controllers
{
    public class VerController : Controller
    {
        TblRecetaCTRL Receta2 = new TblRecetaCTRL();
        // GET: Tabla
        public ActionResult MisRecetas()
        {
            if (Session["ID"] != null)
            {
                ViewBag.RecetaList = Receta2.TraerTablaReceta(int.Parse(Session["ID"].ToString()));
                return View();
            }
            else
                return RedirectToAction("../Acceso/Login");
        }

        public ActionResult Publicaciones()
        {
            if (Session["ID"] != null)
            {
                ViewBag.RecetaList = Receta2.TraerReceta();
                return View();
            }
            else
                return RedirectToAction("../Acceso/Login");
        }
        
    }    
}
