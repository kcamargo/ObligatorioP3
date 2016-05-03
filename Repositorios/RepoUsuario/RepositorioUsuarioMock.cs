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

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> origin/Alta_Anuncio
        public bool FindById()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
=======
>>>>>>> origin/master
=======
>>>>>>> origin/Alta_Anuncio
        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        //<<<<<<< HEAD
        //        public bool FindById()
        //        {
        //            throw new NotImplementedException();
        //        }

        //=======
        //>>>>>>> origin/master
        //        public Usuario FindById(int id)
        //        {
        //            throw new NotImplementedException();
        //        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
