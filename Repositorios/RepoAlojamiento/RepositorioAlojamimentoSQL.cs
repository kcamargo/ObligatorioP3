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
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Alojamiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj) { return obj != null & obj.Update(); }

        public IEnumerable<Alojamiento> FindAlojamientoByNombre(string nom)
        {
            string cadenaSQL = @"SELECT * FROM Alojamiento  WHERE nom=@nombre ";
            SqlConnection cn = null;
            try
            {
                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.Add(new SqlParameter("@nombre", nom));
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Alojamiento a = new Alojamiento
                        {
                            TipoHabitacion = dr["tipo_habitacion"].ToString(),
                            TipoBanio = dr["tipo_banio"].ToString(),
                            CapacidadXPersona = (int)dr["capacidad_personas"],
                            Ciudad = dr["ciudad"].ToString(),
                            Barrio = dr["barrio"].ToString(),
                            TipoAlojamiento = dr["tipo_alojamiento"] == System.DBNull.Value ? "" : dr["tipo_alojamiento"].ToString(),

                        };
                        return a;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se puede cargar el alojamiento");
            }

        }

    }
}



