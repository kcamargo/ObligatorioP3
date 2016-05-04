using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using DAL;

namespace BienvenidosUYservice
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ListarAnuncio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ListarAnuncio.svc o ListarAnuncio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ListarAnuncio : IListarAnuncio
    {
        public List<Anuncio> GetAll()
        {
            List<Anuncio> lst = new List<Anuncio>();
            SqlDataReader dr = DALanuncio.select_All();
            while (dr.Read())
            {

                lst.Add(cargarAnuncio(dr));
            }

            return lst;
        }

        public Anuncio GetAnuncio(int id)
        {
            SqlDataReader dr = DALPersona.select_byId(id);
            Anuncio p = null;
            if (dr != null && dr.Read())
            {
                //p = cargarAnuncio(dr);
            }
            return p;
        }


        Anuncio cargarAnuncio(SqlDataReader dr)
        {

            Anuncio a = new Anuncio();
            a.Apellido = dr["Apellido"].ToString();
            p.Nombre = dr["Nombre"].ToString();
            p.Id = int.Parse(dr["id"].ToString());
            return p;

        }
    }
}
