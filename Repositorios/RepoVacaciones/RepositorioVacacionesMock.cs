using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoVacaciones
{
    public class RepositorioVacacionesMock : IRepositorioVacaciones
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Vacaciones obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Vacaciones> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Vacaciones FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Vacaciones obj)
        {
            throw new NotImplementedException();
        }
    }
}
