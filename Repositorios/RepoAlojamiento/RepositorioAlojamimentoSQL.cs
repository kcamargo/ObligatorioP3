using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Data.SqlClient;
using UtilidadesBD;
using System.Configuration;

namespace Repositorios.RepoAlojamiento
{
    public class RepositorioAlojamimentoSQL : IRepositorioAlojamiento
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            //if obj.validar == false return false;
            string cadenaConexion = ConfigurationManager.
                 ConnectionStrings["conexionBienvenidosUy"].ConnectionString;
            SqlConnection cn = new SqlConnection(cadenaConexion);

            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = @"INSERT INTO Alojamiento VALUES (@nombre, @tipoHabitacion, @tipoBanio, @capacidadPersonas)";
            cmdInsert.Connection = cn;

            cmdInsert.Parameters.AddWithValue(("@nombre", labelNombreAlojamiento.text));
            cmdInsert.Parameters.AddWithValue("@idDir", 1);//obj.direccionPostal.Id
            cmdInsert.Parameters.AddWithValue("@tel", "20000012");//obj.Telefono
            cmdInsert.Parameters.AddWithValue("@email", "a@x.com");
            cmdInsert.Parameters.AddWithValue("@encargado", "Juan");
            cmdInsert.Parameters.AddWithValue("@estado", 1);//obj.Estado.Id

            cn.Open();
            int afectadas = cmdInsert.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            if (afectadas == 1) return true;
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Alojamiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Alojamiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
