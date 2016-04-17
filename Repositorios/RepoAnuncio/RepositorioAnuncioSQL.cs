using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositorios.RepoAnuncio
{
    public class RepositorioAnuncioSQL : IRepositorioAnuncio
    {
        public bool Add(Anuncio obj)
        {
            //if obj.validar == false return false;
            string cadenaConexion = ConfigurationManager.
                 ConnectionStrings["conexionBienvenidosUy"].ConnectionString;
            SqlConnection cn = new SqlConnection(cadenaConexion);

            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = @"INSERT INTO Anuncios VALUES (@nombreAnuncio, @descripcionAnuncio, @precioBase)";
            cmdInsert.Connection = cn;

            cmdInsert.Parameters.AddWithValue("@nombreAnuncio", obj.NombreAnuncio);
            cmdInsert.Parameters.AddWithValue("@descripcionAnuncio", obj.DescripcionAnuncio);
            cmdInsert.Parameters.AddWithValue("@precioBase", obj.PrecioBase);
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

        public List<Anuncio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Anuncio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Anuncio obj)
        {
            throw new NotImplementedException();
        }
    }
}
