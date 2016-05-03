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
using System.Data;

namespace Repositorios.RepoTemporada
{
    public class RepositorioTemporadaSQL : IRepositorioTemporada
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Temporada obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {

            Temporada o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Temporada> FindAll()
        {
            string cadenaSQL = @"SELECT *  From Vacaciones";
            SqlConnection cn = null;
            List<Temporada> lista = new List<Temporada>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Temporada v = new Temporada();
                        v.Load(dr);
                        lista.Add(v);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se pueden cargar las temporadas del anuncio");
                return null;
            }
        }

        public BienvenidosUyBLL.EntidadesNegocio.Temporada FindById(int id)
        {
            string cadenaSQL = @"SELECT * From Temporadas where id=@id";
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
                        Temporada v = new Temporada
                        {
                            Id = (int)dr["id"],
                            FechaInicio = Convert.ToDateTime(dr["fecha_inicio"] == DBNull.Value ? null : dr["fecha_inicio"].ToString()),
                            FechaFin = Convert.ToDateTime(dr["fecha_fin"] == DBNull.Value ? null : dr["fecha_fin"].ToString()),
                            Importe = Int32.Parse(dr["importe"] == DBNull.Value ? null : dr["importe"].ToString()),
                            Id_anuncio = Int32.Parse(dr["id_anuncio"] == DBNull.Value ? null : dr["id_anuncio"].ToString()),

                        };

                        return v;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + "No se pueden cargar las vacaciones con id: " + id);
                return null;
            }
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Temporada obj)
        {
            return obj != null & obj.Update();
        }

        public List<Temporada> FindByIdAlojamiento(int id)
        {
            string cadenaSQL = @"SELECT *  From Vacaciones WHERE id=@id";
            SqlConnection cn = null;
            List<Temporada> lista = new List<Temporada>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Temporada v = new Temporada();
                        v.Load(dr);
                        lista.Add(v);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se pueden cargar las vacaciones");
                return null;
            }
        }

        public List<Temporada> FindByIdAnuncio(int id)
        {
            string cadenaSQL = @"SELECT *  From Temporadas WHERE id_anuncio=@id_anuncio";
            SqlConnection cn = null;
            List<Temporada> lista = new List<Temporada>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@id_anuncio", id);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Temporada v = new Temporada();
                        v.Load(dr);
                        lista.Add(v);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se pueden cargar las temporadas correspondientes al anuncio");
                return null;
            }
        }
    }
}
