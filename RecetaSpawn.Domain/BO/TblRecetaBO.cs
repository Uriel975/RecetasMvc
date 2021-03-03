using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.BO
{
    public class TblRecetaBO
    {

        int ID_Recetas;
        string Receta;
        string Tiempo;
        string Ingredientes;
        string Preparacion ;
        int FkUsuario;

        public int ID_RECETA
        {
            get { return ID_Recetas; }
            set { ID_Recetas = value; }
        }
        public string RECETA
        {
            get { return Receta; }
            set { Receta = value; }
        }
        public string TIEMPO
        {
            get { return Tiempo; }
            set { Tiempo = value; }
        }
        public string INGREDIENTES
        {
            get { return Ingredientes; }
            set { Ingredientes = value; }
        }
        public string PREPARACION
        {
            get { return Preparacion; }
            set { Preparacion = value; }
        }
        public int FKUSUARIO
        {
            get { return FkUsuario; }
            set { FkUsuario = value; }
        }
    }
}
