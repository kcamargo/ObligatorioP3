using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoReserva
{
    public class RepositorioReservaMock : IRepositorioReserva
    {
        public bool Add(Reserva obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> FindAll()
        {
            throw new NotImplementedException();
        }

        public Reserva FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reserva obj)
        {
            throw new NotImplementedException();
        }
    }
}
