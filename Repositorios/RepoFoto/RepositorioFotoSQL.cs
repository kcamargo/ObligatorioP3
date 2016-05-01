using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoFoto
{
    public class RepositorioFotoSQL : IRepositorioFoto
    {
        public bool Add(Foto obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Foto o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<Foto> FindAll()
        {
            throw new NotImplementedException();
        }

        public Foto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Foto obj)
        {
            return obj != null & obj.Update();
        }
    }
}
