using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.Service
{
    public class TblUsuarioCTRL
    {

		//int
		TblUsuarioDAO Metodo = new TblUsuarioDAO();
		
		public int Agregar(TblUsuariosBO obj)
        {
			int final=0;
			final = Metodo.Agregar(obj);
			return final;
        }


		public List<TblUsuariosBO> Traer()  
		{
			List<TblUsuariosBO> datos = new List<TblUsuariosBO>();
			datos = Metodo.BuscarUsuarios();
			return datos;
		}
		public int Eliminar(int id)
        {
			int Delete = 0;
			Delete = Metodo.Eliminar(id);
			return Delete;

        }

		public int Actualizar(TblUsuariosBO obj)
		{
			int final = 0;
			final = Metodo.Actualizar(obj);
			return final;
		}

		public List<TblUsuariosBO> Validar(TblUsuariosBO obj)
        {
			List<TblUsuariosBO> datos = new List<TblUsuariosBO>();
			datos = Metodo.TraerUsuario(obj);
			return datos;
		}

	}
}

	