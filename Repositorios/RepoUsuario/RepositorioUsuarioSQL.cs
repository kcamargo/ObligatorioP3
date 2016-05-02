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

         public bool FindByEmail(string email)

        {
            string CADENABUSCAR = "SELECT email FROM Usuarios WHERE email=@email";
            string usuarioEmail;

            using (SqlConnection cn = BdSQL.Conectar())
            {

                using (SqlCommand cmd = new SqlCommand(CADENABUSCAR, cn))
                {

                    cmd.Parameters.AddWithValue("@email", email);
                    BdSQL.AbrirConexion(cn);
                    usuarioEmail = (String)cmd.ExecuteScalar();
                    BdSQL.CerrarConexion(cn);
                    cn.Dispose();
                }
            }
                    if (usuarioEmail == email)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                
            

        Usuario IRepositorioUsuario.FindByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }

}
    }
}
