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
    }
}
