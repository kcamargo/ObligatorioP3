using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCliente.ServiceReference1;

namespace WCFCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ListarAnunciosClient cliente = new ServiceReference1.ListarAnunciosClient();
            cliente.Open();
            Anuncio[] anuncios = cliente.GetAll();
            foreach (Anuncio a in anuncios)
            {
                Console.WriteLine(a.NombreAnuncio + ", " + a.DescripcionAnuncio + ", " + a.Direccion + ", " + a.Feriados);
                
            }
            cliente.Close();
            Console.ReadKey();
        }
    }
}
