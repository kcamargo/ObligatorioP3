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
    public class Servicio : IEntity
    {
        #region PROPERTIES

        public string Nombre { get; set; }

        public string Descripcion{ get; set; }

        public int Id { get; set ; }

        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertServicio = "INSERT INTO Alojamiento VALUES (@nombre)";
        private string cadenaUpdateServicio = "UPDATE  Alojamiento SET nombre=@nombre WHERE id=@id";
        private string cadenaDeleteServicio = "DELETE  Alojamiento WHERE id=@id";

        #endregion


        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsertServicio, cn))
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
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateServicio, cn))
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
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteServicio, cn))
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

                this.Id = (int)dr["id"];
                this.Nombre = dr["nombre"].ToString();
                this.Descripcion = dr["descripcion"].ToString();

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
