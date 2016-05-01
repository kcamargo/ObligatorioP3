using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Foto : IEntity
    {
        public int Id { get; set; }

        public Anuncio Anuncio { get; set; }

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
    }
}
