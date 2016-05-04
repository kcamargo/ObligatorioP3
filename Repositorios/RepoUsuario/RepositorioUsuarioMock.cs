using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoUsuario
{
    public class RepositorioUsuarioMock : IRepositorioUsuario
    {
        public bool Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool FindById()
        {
            throw new NotImplementedException();
        }


        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindByPassword(string pasw)
        {
            throw new NotImplementedException();
        }

        public Usuario FindByPassword(string email, string pasw)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
