using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoFoto
{
    public class RepositorioFotoMock : IRepositorioFoto
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Foto obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Foto> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Foto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Foto> FindByIdAnuncio(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Foto obj)
        {
            throw new NotImplementedException();
        }
    }
}
