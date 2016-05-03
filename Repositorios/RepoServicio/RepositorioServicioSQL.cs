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

namespace Repositorios.RepoServicio
{
    public class RepositorioServicioSQL : IRepositorioServicio
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Servicio obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Servicio> FindAll()
        {
            string cadenaSQL = @"SELECT id, nombre, descripcion From Servicios";
            SqlConnection cn = null;
            List<Servicio> listaServicios = new List<Servicio>();
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    //Preparar el comando d 
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    //Ejecutar el comando para  obtener el reader con las tuplas requeridas
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    //No es necesario un while, como máximo hay una fila para leer

                    while (dr.Read())
                    {
                        Servicio s = new Servicio();
                        s.Load(dr);//Carga los datos propios de la Organización
                                   //Se crea un objeto estado por simplicidad, con los datos traidos desde
                                   //el join, pero en realidad debería verificarse que ya no esté cargado


                        listaServicios.Add(s);

                    }
                }
                return listaServicios;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se pueden cargar los servicios");
                return null;
            }
        }

        public BienvenidosUyBLL.EntidadesNegocio.Servicio FindById(int id)
        {

            Servicio s = null;
            string cadenaSQL = @"SELECT id, nombre, descripcion FROM Servicios WHERE id=@id";
            SqlConnection cn = null;
            try
            {

                using (cn = UtilidadesBD.BdSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(cadenaSQL, cn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    BdSQL.AbrirConexion(cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr != null && dr.Read())
                    {
                        s = new Servicio();
                        s.Load(dr);
                    }
                }
                return s;
            }
            catch (Exception ex)
            {

                BdSQL.LoguearError(ex.Message + "No se puede cargar el Servicio");
                return null;
            }
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Servicio obj)
        {
            throw new NotImplementedException();
        }
    }
}
