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
    public class TblCategoriasDAO
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Conexion con2 = new Conexion();
        string sql;

        public int AgregarCategoria(TblCategoriasBO dato)
        {
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "INSERT INTO tblCategoria(Categoria) VALUES (@Categoria)";

			cmd.Parameters.AddWithValue("@Categoria", dato.Categoria);

			cmd.CommandText = sql;
			int x = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (x <= 0)
			{
				return 0;
			}
			return 1;
		}

		public List<TblCategoriasBO> TraerCategoria()
        {
			List<TblCategoriasBO> lista = new List<TblCategoriasBO>();
			string sql = "select * from TblCategoria";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable table = new DataTable();
			da.Fill(table);
			if (table.Rows.Count > 0)
			{
				foreach (DataRow row in table.Rows)
				{
					TblCategoriasBO obj = new TblCategoriasBO();
					obj.IDCategoria = int.Parse(row["IDCategoria"].ToString());
					obj.Categoria = row["Categoria"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}
    }

}
