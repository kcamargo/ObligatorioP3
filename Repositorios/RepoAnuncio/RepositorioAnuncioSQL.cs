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

namespace Repositorios.RepoAnuncio
{
    public class RepositorioAnuncioSQL : IRepositorioAnuncio
    {
        public bool Add(Anuncio obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Anuncio o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<Anuncio> FindAll()
        {
            string cadenaSQL = @"SELECT *  From Anuncios";
            SqlConnection cn = null;
            List<Anuncio> lista = new List<Anuncio>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Anuncio a = new Anuncio();
                        a.Load(dr);
                        lista.Add(a);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se puede cargar los anuncios");
                return null;
            }
        }

        public Anuncio FindById(int id)
        {
            string cadenaSQL = @"SELECT * From Anuncios where id=@id";
            SqlConnection cn = null;

            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Anuncio a = new Anuncio
                        {
                            Id = (int)dr["id"],
                            NombreAnuncio = dr["nombre"] == DBNull.Value ? null : dr["nombre"].ToString(),
                            DescripcionAnuncio = dr["descripcion"] == DBNull.Value ? null : dr["descripcion"].ToString(),
                            PrecioBase = (int)dr["precio_base"],
                            Direccion = dr["direccion"] == DBNull.Value ? null : dr["direccion"].ToString(),
                            //a.Alojamiento.Id = (int)dr["id_alojamiento"],

                        };

                        return a;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + "No se puede cargar el Anuncio con id =" + id);
                return null;
            }
        }

        public bool Update(Anuncio obj)
        {
            return obj != null & obj.UpdateAnuncio();
        }
    }
}

