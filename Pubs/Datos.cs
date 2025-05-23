using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen3
{
    public class Datos
    {
		string cadenaConexion = "Data Source=THINKPAD_CJ\\SQLEXPRESS; initial catalog = examen3; integrated security = true;";
		SqlConnection conexion = null;
        private SqlConnection abrirConexcion()
        {
			try
			{
				conexion = new SqlConnection(cadenaConexion);
				conexion.Open();
				return conexion;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
				throw;
			}
        }

		private void cerrarConexion()
		{
			try
			{
				if (conexion.State ==  System.Data.ConnectionState.Open)
				{
					conexion.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}

		public DataSet comando(string comando)
		{
			DataSet ds = new DataSet();
			try
			{
				SqlDataAdapter cmd = new SqlDataAdapter(comando, abrirConexcion());
				cmd.Fill(ds);
				return ds;
				
			}
			catch (Exception ex)
			{
				// Console.WriteLine(ex.Message);
				return null;
				throw;
			}
			finally
			{
				if (ds!=null)
				{
					cerrarConexion();
				}
			}
		}

		public bool executeCmd(string scomando)
		{
			try
			{
				SqlCommand comando = new SqlCommand(scomando, abrirConexcion());
				comando.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
				throw;
			}
			finally { 
				
			}
		}
    }
}
