using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Reserva : IEntity
    {
        #region PROPERTIES

        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int CantidadPersonas { get; set; }

        public Anuncio HospedajeSelect { get; set; }

        public List<Alojamiento> AlojamientoSelect;

        public double PrecioTotal { get; set; }

        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertReserva = "INSERT INTO Alojamiento VALUES (@nombre)";
        private string cadenaUpdateReserva = "UPDATE  Alojamiento SET nombre=@nombre WHERE id=@id";
        private string cadenaDeleteReserva = "DELETE  Alojamiento WHERE id=@id";

        #endregion


        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsertReserva, cn))
                    {
                        // cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }
                }
            }
            return false;
        }
        public bool Update()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateReserva, cn))
                    {
                        //cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        //cmd.Parameters.AddWithValue("@id", this.Id);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }
                }
            }
            return false;
        }
        public bool Delete()
        {

            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteReserva, cn))
                {

                    //cmd.Parameters.AddWithValue("@id", this.Id);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }

        }
        public void Load(IDataRecord dr)
        {
            if (dr != null)
            {
                //this.Nombre = dr["nombre"].ToString();
                this.Id = Convert.ToInt32(dr["id"]);
            }
        }
        #endregion

        #region VALIDACIONES

        public bool Validar()
        {
            return true; //this.Nombre.Length >= 3;
        }


        #endregion

        #region REDEFINICIONES DE OBJECT
        public override string ToString()
        {
            return this.Id + " - ";
        }
        #endregion

    }
}
