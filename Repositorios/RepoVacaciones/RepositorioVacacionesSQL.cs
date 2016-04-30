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

namespace Repositorios.RepoVacaciones
{
    public class RepositorioVacacionesSQL : IRepositorioVacaciones
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Vacaciones obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {

            Vacaciones o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Vacaciones> FindAll()
        {
            string cadenaSQL = @"SELECT *  From Vacaciones";
            SqlConnection cn = null;
            List<Vacaciones> lista = new List<Vacaciones>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Vacaciones v = new Vacaciones();
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

        public BienvenidosUyBLL.EntidadesNegocio.Vacaciones FindById(int id)
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
                        Vacaciones v = new Vacaciones
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

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Vacaciones obj)
        {
            return obj != null & obj.Update();
        }

        public List<Vacaciones> FindByIdAlojamiento(int id)
        {
            string cadenaSQL = @"SELECT *  From Vacaciones WHERE id=@id";
            SqlConnection cn = null;
            List<Vacaciones> lista = new List<Vacaciones>();
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
                        Vacaciones v = new Vacaciones();
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
