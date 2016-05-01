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
    public class Temporada : IEntity
    {
        #region PROPERTIES

        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int Importe { get; set; }

        public int Id_anuncio { get; set; }



        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL2

        private string cadenaInsertTemporadas = @"INSERT INTO Temporadas VALUES (@fecha_inicio, @fecha_fin, @importe, id_anuncio)SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaUpdateTemporadas = @"UPDATE  Temporadas SET fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin, importe=@importe, id_anuncio=@id_anuncio  WHERE id=@id";
        private string cadenaDeleteTemporadas = @"DELETE  Temporadas WHERE id=@id";



        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                SqlCommand cmd = new SqlCommand(cadenaInsertTemporadas, cn);
                cmd.Parameters.Add(new SqlParameter("@fecha_inicio", this.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fecha_fin", this.FechaFin));
                cmd.Parameters.Add(new SqlParameter("@importe", this.Importe));
                cmd.Parameters.Add(new SqlParameter("@id_anuncio", this.Id_anuncio));
                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                this.Id = (int)cmd.ExecuteScalar();
                trn.Commit();
                trn.Dispose();
                trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar el rango de vacaciones ");
                if (trn != null) trn.Rollback();
                return false;
            }
            finally
            {
                BdSQL.CerrarConexion(cn);
            }
        }
        public bool Update()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateTemporadas, cn))
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
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteTemporadas, cn))
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
                this.Id = Convert.ToInt32(dr["id"]);
                this.FechaInicio = DateTime.Parse(dr["fecha_inicio"].ToString());
                this.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                this.Importe = (int)dr["importe"];
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
