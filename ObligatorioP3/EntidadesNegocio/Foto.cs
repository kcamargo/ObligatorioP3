using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Foto : IEntity
    {
        public int Id { get; set; }

        public int Anuncio { get; set; }

        public string Url { get; set; }


        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public void Load(IDataRecord dr)
        {
            if (dr == null) return;
            this.Id = (int)dr["Id"];
            this.Url = dr["url"] == DBNull.Value ? null : dr["url"].ToString();
            this.Anuncio = (int)dr["id_anuncio"];
           
        }
    }
}
