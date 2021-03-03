using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.Service
{
    public class TblCategoriasCTRL
    {
        TblCategoriasDAO metodo = new TblCategoriasDAO();
        public int agregar(TblCategoriasBO Categoria)
        {
            int dev = 0;
            return dev = metodo.AgregarCategoria(Categoria);
        } 

        public List<TblCategoriasBO> Traer()
        {
            List<TblCategoriasBO> lista = new List<TblCategoriasBO>();
            return lista = metodo.TraerCategoria();
        }
    }
}
