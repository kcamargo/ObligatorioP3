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
    public class Anuncio : IEntity
    {
        #region PROPERTIES
        public int Id { get; set; }

        public List<Alojamiento> AlojamientosDisponibles;

        public string NombreAnuncio { get; set; }

        public string DescripcionAnuncio { get; set; }
        public string Direccion1 { get; set; }

        public string Direccion2 { get; set; }

        public List<Foto> FotosAnuncio { get; set; }

        public int PrecioBase { get; set; }

        public List<Vacaciones> Feriados;

        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertAnuncio = "INSERT INTO Alojamiento VALUES (@nombre)";
        private string cadenaUpdateAnuncio = "UPDATE  Alojamiento SET nombre=@nombre WHERE id=@id";
        private string cadenaDeleteAnuncio = "DELETE  Alojamiento WHERE id=@id";

        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsertAnuncio, cn))
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
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateAnuncio, cn))
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
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteAnuncio, cn))
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
