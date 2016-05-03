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

namespace Repositorios.RepoAlojamiento
{

    public class RepositorioAlojamimentoSQL : IRepositorioAlojamiento
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Alojamiento o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Alojamiento> FindAll()
        {
            string cadenaSQL = @"SELECT *  From Alojamientos";
            SqlConnection cn = null;
            List<Alojamiento> lista = new List<Alojamiento>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Alojamiento a = new Alojamiento();
                        a.Load(dr);
                        lista.Add(a);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se puede cargar los alojamientos");
                return null;
            }
        }

        public BienvenidosUyBLL.EntidadesNegocio.Alojamiento FindById(int id)
        {
            string cadenaSQL = @"SELECT * From Alojamientos where id=@id";
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
                        Alojamiento a = new Alojamiento
                        {
                            Id = (int)dr["id"],
                            Nombre = dr["Nombre"] == DBNull.Value ? null : dr["Nombre"].ToString(),
                            TipoHabitacion = dr["tipo_habitacion"] == DBNull.Value ? null : dr["tipo_habitacion"].ToString(),
                            TipoBanio = dr["tipo_banio"] == DBNull.Value ? null : dr["tipo_banio"].ToString(),
                            CapacidadXPersona = (int)dr["capacidad_personas"],
                            Ciudad = dr["ciudad"] == DBNull.Value ? null : dr["ciudad"].ToString(),
                            Barrio = dr["barrio"] == DBNull.Value ? null : dr["barrio"].ToString(),
                            TipoDeServicios = GetAllAlojamientosServiciosXIdAlojamiento(id),

                        };

                        return a;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + "No se puede cargar el Alojamiento con id=" + id);
                return null;
            }
        }

        public List<Servicio> GetAllAlojamientosServiciosXIdAlojamiento(int id)
        {
            string cadenaSQL = @"SELECT *  From alojamientoServicio WHERE id_Alojamiento=@id_Alojamiento";
            SqlConnection cn = null;
            List<Servicio> lista = new List<Servicio>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@id_Alojamiento", id);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    IRepositorioServicio rs = new Repositorios.RepoServicio.RepositorioServicioSQL();
                    while (dr.Read())
                    {
                        Servicio s = rs.FindById((int)dr["id_servicio"]);
                        lista.Add(s);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se puede cargar los alojamientos");
                return null;
            }
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj) { return obj != null & obj.Update(); }


    }

}



