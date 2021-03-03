using RecetaSpawn.Domain.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.DAO
{
    public class TblRecetaDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public List<TblRecetaBO> ListarTablaReceta()
		{
			List<TblRecetaBO> lista = new List<TblRecetaBO>();
			sql = "select * from TblReceta";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblRecetaBO obj = new TblRecetaBO();
					obj.ID_RECETA = int.Parse(row["ID_Recetas"].ToString());
					obj.RECETA = (row["Receta"]).ToString();
					obj.TIEMPO = (row["Tiempo"]).ToString();
					obj.INGREDIENTES = (row["Ingredientes"]).ToString();
					obj.PREPARACION = (row["Preparacion"]).ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}

		//Trae Recetas Del Usuario 
		public List<TblRecetaBO> ListarTabla(int ID)
        {
			List<TblRecetaBO> lista2 = new List<TblRecetaBO>();
			sql = "select * from TblReceta where FkUsuario = "+ID+"";
			SqlDataAdapter de = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla2 = new DataTable();
			de.Fill(tabla2);
			if (tabla2.Rows.Count > 0)
			{
				foreach (DataRow row in tabla2.Rows)
				{
					TblRecetaBO obj = new TblRecetaBO();
					obj.ID_RECETA = int.Parse(row["ID_Recetas"].ToString());
					obj.RECETA = (row["Receta"]).ToString();
					obj.TIEMPO = (row["Tiempo"]).ToString();
					obj.INGREDIENTES = (row["Ingredientes"]).ToString();
					obj.PREPARACION = (row["Preparacion"]).ToString();
					lista2.Add(obj);
				}
			}
			return lista2;

		}
		//Agregar Receta
		public int Agregar(TblRecetaBO Crear)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "INSERT INTO TblReceta(Receta, Tiempo, Ingredientes, Preparacion, FkUsuario) VALUES (@Receta, @Tiempo, @Ingredientes, @Preparacion, @FkUsuario)";

			cmd.Parameters.AddWithValue("@Receta", Crear.RECETA);
			cmd.Parameters.AddWithValue("@Tiempo", Crear.TIEMPO);
			cmd.Parameters.AddWithValue("@Ingredientes", Crear.INGREDIENTES);
			cmd.Parameters.AddWithValue("@Preparacion", Crear.PREPARACION);
			cmd.Parameters.AddWithValue("@FkUsuario", Crear.FKUSUARIO);
			//T-T

			cmd.CommandText = sql;
			int x = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (x <= 0)
			{
				return 0;
			}
			return 1;
		}

		public int Eliminar(int id)
        {
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "DELETE TblReceta WHERE ID_Recetas=@ID_Recetas";
			cmd.Parameters.AddWithValue("@ID_Recetas", id);


			cmd.CommandText = sql;
			int x = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (x <= 0)
			{
				return 0;
			}
			return 1;
		}

		public int Actualizar(TblRecetaBO obj)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "UPDATE TblReceta SET Receta=@Receta, Tiempo=@Tiempo, Ingredientes=@Ingredientes, Preparacion=@Preparacion WHERE ID_Recetas=@ID_Recetas";
			cmd.Parameters.AddWithValue("@Receta", obj.RECETA);
			cmd.Parameters.AddWithValue("@Tiempo", obj.TIEMPO);
			cmd.Parameters.AddWithValue("@Ingredientes", obj.INGREDIENTES);
			cmd.Parameters.AddWithValue("@Preparacion", obj.PREPARACION);
			cmd.Parameters.AddWithValue("@ID_Recetas", obj.ID_RECETA);

			cmd.CommandText = sql;
			int x = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (x <= 0)
			{
				return 0;
			}
			return 1;
		}
	}
}
