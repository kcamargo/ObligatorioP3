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

                BdSQL.LoguearError(ex.Message + "No se pueden cargar las vacaciones");
                return null;
            }
        }

        public BienvenidosUyBLL.EntidadesNegocio.Temporada FindById(int id)
        {
            string cadenaSQL = @"SELECT * From Vacaciones where id=@id";
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
                            //Id = (int)dr["id"],
                            //Nombre = dr["Nombre"] == DBNull.Value ? null : dr["Nombre"].ToString(),
                            //TipoHabitacion = dr["tipo_habitacion"] == DBNull.Value ? null : dr["tipo_habitacion"].ToString(),
                            //TipoBanio = dr["tipo_banio"] == DBNull.Value ? null : dr["tipo_banio"].ToString(),
                            //CapacidadXPersona = (int)dr["capacidad_personas"],
                            //Ciudad = dr["ciudad"] == DBNull.Value ? null : dr["ciudad"].ToString(),
                            //Barrio = dr["barrio"] == DBNull.Value ? null : dr["barrio"].ToString(),
                            //TipoDeServicios = GetAllAlojamientosServiciosXIdAlojamiento(id),

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
    }
}
