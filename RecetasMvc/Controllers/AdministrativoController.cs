using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecetasMvc.Controllers
{
    public class AdministrativoController : Controller
    {
        // GET: Admin
        // Vienes aqui a tu vista, escribes una nueva, click derecho
        // Si estaba bien lo que hacias, solo que si te fijas, lo que hacias es que ahi tenia un avista innexistente (creo que lo escribi mal)
        // ya que buscaba AdminView en el controlador (aqui) y dime, vez alguna vista con ese nombre?
        // pero nmms si vine tambien aqui y puse este puto nombre que tenia Admin y l puse en el layout, 
        //Si, pero aqui en el controlador no existe, 
        // ptm ya entendi....estaba poniendo otro nobre diferente al que esta en share!!! asi es no?
        //Ahi donde marque indica en que controlador va a buscar, puedes ver que este es AdminCOntroller, eso quiere decir que dentro de este controlador buscara
        //AdminView, pero como tu no tenias a una vista con ese nombre. eso que marque, por eso fallaba, solo no creaste la vista
        //por eso te digo ya te entendi, mira, asi como tengo de nombre esto, asi lo tengo que asignar?
        // nou... todo, esta bien, solo la vista, la pagina que debes buscar, no tenias!! TOdo lo demas esta bien y no tiene nada que ver con el nombre este
        //ptm asi no entiendo as escrito, te llamo rapido ?! lo tomare como un 
        public ActionResult IndexEjemplo()
        {
            return View();
        }

        public ActionResult AdminView()
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

        public ActionResult ClientView()
        {
            if (Session["ID"] != null)
            {
                if (Session["Rol"].ToString() == "Cliente")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Acceso/Login");
            }
            else
                return RedirectToAction("../Acceso/Login");
        }
    }
}