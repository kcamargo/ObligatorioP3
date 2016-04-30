using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Configuration;
using System.Data.SqlClient;
using UtilidadesBD;

namespace Repositorios.RepoUsuario
{
    public class RepositorioUsuarioSQL : IRepositorioUsuario
    {


        public Usuario FindByEmail(string email)

        {
            string CADENABUSCAR = "SELECT * FROM Usuario WHERE email_Usuario=@email";
            Usuario usuarioEncontrado = null;

            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(CADENABUSCAR, cn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {

                            Usuario U = new Usuario();
                            U.Load(reader);
                            U.Email = email;
                            if (U.Validar())
                            {

                                usuarioEncontrado = U;

                            }

                        }


                    }

                }
                return usuarioEncontrado;

            }
        }
        public bool Add(Usuario obj)
        {

            return obj.Add();
           
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool Validar(string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
