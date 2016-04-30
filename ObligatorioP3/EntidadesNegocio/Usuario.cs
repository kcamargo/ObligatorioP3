using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Usuario : IEntity
    {
        #region PROPERTIES
        public int Id { get; set; }

        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string ApellidoUsuario { get; set; }
        public string IdUser { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public List<Usuario> lista;
        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertUsuario = "INSERT INTO Usuarios VALUES (@nombre_Usuario,@contraseña, @apellido_Usuario,@direccion_Usuario,@telefono_Usuario,@descripcion_Usuario,@email_Usuario, @foto )";
        private string cadenaUpdateUsuario = "UPDATE  Usuarios SET nombre_Usuario=@nombre_Usuario, contraseña=@contraseña,apellido_Usuario=@apellido_Usuario, direccion_Usuario=@direccion_Usuario, telefono_Usuario=@telefono_Usuario, descripcion_Usuario=@descripcion_Usuario,email_Usuario=email_Usuario,foto= @foto WHERE email_Usuario=@email_Usuario";
        private string cadenaDeleteUsuario = "DELETE  Usuarios WHERE email_Usuario=@email_Usuario";


        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                //Preparar el comando de inserción
                SqlCommand cmd = new SqlCommand(cadenaInsertUsuario, cn);
                cmd.Parameters.Add(new SqlParameter("@nombre_Usuario", this.NombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@apellido_Usuario", this.ApellidoUsuario));
                cmd.Parameters.Add(new SqlParameter("@contraseña", this.Contraseña));
                cmd.Parameters.Add(new SqlParameter("@direccion_Usuario", this.Direccion));
                cmd.Parameters.Add(new SqlParameter("@telefono_Usuario", this.Telefono));
                cmd.Parameters.Add(new SqlParameter("@descripcion_Usuario", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@emali_Usuario", this.Email));
                cmd.Parameters.Add(new SqlParameter("@foto", this.Foto));


                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                
                //La transacción y la conexión permanecen incambiadas

                //Si se llegó aquí se asume que podemos completar la transacción
                trn.Commit();
                
                //trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar el usuario " + this.NombreUsuario);
                if (trn != null) trn.Rollback();
                return false;
            }
            finally
            {
                BdSQL.CerrarConexion(cn);
                cn.Dispose();
                trn.Dispose();
            }
        }


        public bool UpdateUsuario()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateUsuario, cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@nombre_Usuario", this.NombreUsuario));
                        cmd.Parameters.Add(new SqlParameter("@apellido_Usuario", this.ApellidoUsuario));
                        cmd.Parameters.Add(new SqlParameter("@contraseña", this.Contraseña));
                        cmd.Parameters.Add(new SqlParameter("@direccion_Usuario", this.Direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono_Usuario", this.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@descripcion_Usuario", this.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@emali_Usuario", this.Email));
                        cmd.Parameters.Add(new SqlParameter("@foto", this.Foto));
                        cn.Open();

                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }

                }
            }
            return false;
        }

        public bool DeleteUsuario(string email)
        {
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteUsuario, cn))
                {

                    //cmd.Parameters.AddWithValue("@email", this.email);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }

        }



        public void Load(IDataRecord dr)
        {
            if (dr == null) return;
            //El operador condicional u operador ternario tiene la siguiente forma: test ? expression1 : expression2
            //y es análogo a if (dr["Nombre]==DBNull.Value) return null else return dr["Nombre"].ToString();
            this.NombreUsuario = dr["nombre_Usuario"] == DBNull.Value ? null : dr["nombre_Usuario"].ToString();
            this.ApellidoUsuario = dr["apellido_Usuario"] == DBNull.Value ? null : dr["apellido_Usuario"].ToString();
            this.Contraseña = dr["contraseña"] == DBNull.Value ? null : dr["contraseña"].ToString();
            this.Telefono = dr["telefono_Usuario"] == DBNull.Value ? null : dr["telefono_Usuario"].ToString();
            this.Descripcion = dr["descripcion_Usuario"] == DBNull.Value ? null : dr["descripcion_Usuario"].ToString();
            this.Direccion = dr["direccion_Usuario"] == DBNull.Value ? null : dr["direccion_Usuario"].ToString();
            this.Direccion = dr["email_Usuario"] == DBNull.Value ? null : dr["email_Usuario"].ToString();
            this.Id = (int)dr["Id"];//este no puede ser dbnull
        }

        #endregion

        #region VALIDACIONES

        public bool Validar()
        {
            return true;// this.NombreUsuario.Length >= 3 && Contraseña.Length >= 8;
        }
        #endregion

        #region Encriptación
        public string SHA1Encrypt(string password)
        {
            System.Security.Cryptography.HashAlgorithm hashValue = new
           System.Security.Cryptography.SHA1CryptoServiceProvider();

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] byteHash = hashValue.ComputeHash(bytes);

            hashValue.Clear();

            return (Convert.ToBase64String(byteHash));
        }


       public bool Validar(string password, string email)
        {
            string traercontraseñaEncriptada = "select contraseña from usuarios where email_Usuario=@emailUsuario";
            {
                SqlConnection cn = null; SqlTransaction trn = null;
                if (!this.Validar()) return false;
                try
                {
                    cn = UtilidadesBD.BdSQL.Conectar();

                    //Preparar el comando
                    SqlCommand cmd = new SqlCommand(traercontraseñaEncriptada, cn);
                    cmd.Parameters.Add(new SqlParameter("@emailUsuario", email));
                    BdSQL.AbrirConexion(cn);
                    trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = trn;
                    string contraseña = (String)cmd.ExecuteScalar();
                    //La transacción y la conexión permanecen incambiadas
                    
                    //Si se llegó aquí se asume que podemos completar la transacción
                    trn.Commit();
                    trn.Dispose();
                    trn = null;
                    if (password == contraseña)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                catch (Exception ex)
                {
                    BdSQL.LoguearError(ex.Message);
                    if (trn != null) trn.Rollback();
                    return false;
                }
                finally
                {
                    BdSQL.CerrarConexion(cn);
                    cn.Dispose();
                }
            }

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

