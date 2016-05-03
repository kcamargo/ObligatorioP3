using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.InterfacesRepositorios
{
    public interface IRepositorioFoto: IRepositorio<Foto>
    {
        List<Foto> FindByIdAnuncio(int id);
    }
}
