using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.InterfacesRepositorios
{
    public interface IRepositorio<T> where T:IEntity
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
        T FindById(int id);
        List<T> FindAll();
    }
}
