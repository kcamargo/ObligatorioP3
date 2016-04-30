using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
         Usuario FindByEmail(string email);
        bool Validar(string password, string email);
    }
}

        