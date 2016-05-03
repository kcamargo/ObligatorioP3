using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.InterfacesRepositorios
{
    public interface IRepositorioTemporada: IRepositorio<Temporada>
    {
        List<Temporada> FindByIdAlojamiento(int id);

        List<Temporada> FindByIdAnuncio(int id);
    }
}
