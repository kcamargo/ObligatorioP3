using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace UtilidadesBD
{
    public class BdSQL
    {
        private static string cadenaConexion =  ConfigurationManager.ConnectionStrings["conexionBienvenidosUy"].ConnectionString;
        public static SqlConnection Conectar()
        {
            try
            {
                return new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {
                LoguearError("Error al conectarse a la bd: " + ex.Message);
                return null;
            }
        }
        public static void AbrirConexion(IDbConnection cn)
        {
            if (cn != null && cn.State != ConnectionState.Open)
                cn.Open();
        }
        public static void CerrarConexion(IDbConnection cn)
        {
            if (cn != null && cn.State != ConnectionState.Closed)
                cn.Close();
        }
        public static void LoguearError(string mensaje)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("errores.log"))
                {
                    sw.WriteLine(mensaje + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                }
            }
            catch (Exception)
            {

                return;
            }
        }

    }
}
