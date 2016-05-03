using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Data.SqlClient;
using UtilidadesBD;

namespace Repositorios.RepoFoto
{
    public class RepositorioFotoSQL : IRepositorioFoto
    {
        public bool Add(Foto obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Foto o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<Foto> FindAll()
        {
            throw new NotImplementedException();
        }

        public Foto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Foto> FindByIdAnuncio(int id_anuncio)
        {
            List<Foto> lista = new List<Foto>();
            string cadenaSQL = @"SELECT * From Fotos where id_anuncio=@id_anuncio";
            SqlConnection cn = null;

            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.AddWithValue("@id_anuncio", id_anuncio);
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Foto f = new Foto();
                        f.Load(dr);
                        lista.Add(f);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + "No se pueden cargar las imagenes");
                return null;
            }
        }

        public bool Update(Foto obj)
        {
            return obj != null & obj.Update();
        }
    }
}
