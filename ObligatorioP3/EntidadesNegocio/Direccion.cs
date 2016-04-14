using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Direccion : IEntity
    {
        public int Id { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }

        internal bool Validar()
        {
            //Una validación arbitraria como ejemplo
            return this.Linea1.Length > 2;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) || (obj as Direccion).Linea1.Equals(this.Linea1);

        }
}
