using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositorios.RepoUsuario
{
    public class RepositorioUsuarioSQL : IRepositorioUsuario
    {
        public bool Add(Usuario obj)
        {
            //if obj.validar == false return false;
            string cadenaConexion = ConfigurationManager.
                 ConnectionStrings["conexionBienvenidosUy"].ConnectionString;
            SqlConnection cn = new SqlConnection(cadenaConexion);

            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = @"INSERT INTO Usuarios VALUES (@nombreUsuario, @apellidoUsuario, @telefonoUsuario)";
            cmdInsert.Connection = cn;

            cmdInsert.Parameters.AddWithValue("@nombreUsuario", obj.NombreUsuario);
            cmdInsert.Parameters.AddWithValue("@apellidoUsuario", obj.ApellidoUsuario);
            cmdInsert.Parameters.AddWithValue("@telefonoUsuario", obj.Telefono);
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

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> origin/Alta_Anuncio
        public bool FindById()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
=======
>>>>>>> origin/master
=======
>>>>>>> origin/Alta_Anuncio
        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        //<<<<<<< HEAD
        //        public bool FindById()
        //        {
        //            throw new NotImplementedException();
        //        }

        //=======
        //>>>>>>> origin/master
        //        public Usuario FindById(int id)
        //        {
        //            throw new NotImplementedException();
        //        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
