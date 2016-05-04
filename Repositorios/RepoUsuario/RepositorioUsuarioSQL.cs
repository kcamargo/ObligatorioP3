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
using System.Security.Cryptography;

namespace Repositorios.RepoUsuario
{
    public class RepositorioUsuarioSQL : IRepositorioUsuario
    {
        public bool Add(Usuario obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool FindById()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindByPassword(string email, string pasw)
        {
            string cadenaSQL = @"SELECT * From Usuarios where email=@email and contrasena=@contrasena";
            SqlConnection cn = null;
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contrasena", Usuario.GetMd5Hash(pasw));
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Usuario u = new Usuario();
                        {
                            u.Id = (int)dr["id"];
                            u.NombreUsuario = dr["nombre"] == DBNull.Value ? null : dr["nombre"].ToString();
                            u.Contraseña = dr["contrasena"] == DBNull.Value ? null : dr["contrasena"].ToString();
                            u.ApellidoUsuario = dr["apellido"] == DBNull.Value ? null : dr["apellido"].ToString();
                            u.Direccion = dr["direccion"] == DBNull.Value ? null : dr["direccion"].ToString();
                            u.Telefono = dr["telefono"] == DBNull.Value ? null : dr["telefono"].ToString();
                            u.Descripcion = dr["descripcion"] == DBNull.Value ? null : dr["descripcion"].ToString();
                            u.Email = dr["email"] == DBNull.Value ? null : dr["email"].ToString();
                        };

                        return u;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + "No se puede cargar el usuario");
                return null;
            }
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }


    }
}
