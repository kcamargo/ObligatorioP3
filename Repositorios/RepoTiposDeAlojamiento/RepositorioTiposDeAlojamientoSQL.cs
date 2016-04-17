using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;
using UtilidadesBD;

namespace Repositorios.RepoTiposDeAlojamiento
{
    public class RepositorioTiposDeAlojamientoSQL : IRepositorioTipoDeAlojamiento
    {
        public bool Add(TipoDeAlojamiento obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoDeAlojamiento> FindAll()
        {
            string cadenaSQL = @"SELECT id, nombre, descripcion From TipoDeAlojamiento";
            SqlConnection cn = null;
            List<TipoDeAlojamiento> listaTipoDeAlojamiento = new List<TipoDeAlojamiento>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoDeAlojamiento ta = new TipoDeAlojamiento();
                        ta.Load(dr);
                        listaTipoDeAlojamiento.Add(ta);

                    }
                }
                return listaTipoDeAlojamiento;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se pueden cargar los tipos de alojamiento");
                return null;
            }
        }

        public TipoDeAlojamiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoDeAlojamiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
