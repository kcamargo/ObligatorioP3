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
        public int IdUser { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public List<Usuario> lista;
        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertUsuario = "INSERT INTO Usuarios VALUES (@nombre,@contrasena, @apellido,@direccion,@telefono,@descripcion,@email, @foto ); SELECT CAST (Scope_Identity()AS INT);";
        private string cadenaUpdateUsuario = "UPDATE  Usuarios SET nombre@nombre, contrasena=@contrasena,apellido=@apellido, direccion=@direccion, telefono=@telefono, descripcion=@descripcion,email=@email,foto= @foto WHERE id=@idUser";
        private string cadenaDeleteUsuario = "DELETE  Usuarios WHERE id=@idUser";


        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                SqlCommand cmd = new SqlCommand(cadenaInsertUsuario, cn);
                cmd.Parameters.Add(new SqlParameter("@nombre", this.NombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@apellido", this.ApellidoUsuario));
                cmd.Parameters.Add(new SqlParameter("@contrasena", this.Contraseña));
                cmd.Parameters.Add(new SqlParameter("@direccion", this.Direccion));
                cmd.Parameters.Add(new SqlParameter("@telefono", this.Telefono));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@email", this.Email));
                cmd.Parameters.Add(new SqlParameter("@foto", this.Foto));


                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                this.IdUser = (int)cmd.ExecuteScalar();
                //La transacción y la conexión permanecen incambiadas

                //Si se llegó aquí se asume que podemos completar la transacción
                trn.Commit();
                trn.Dispose();
                trn = null;
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
                        cmd.Parameters.Add(new SqlParameter("@nombre", this.NombreUsuario));
                        cmd.Parameters.Add(new SqlParameter("@apellido", this.ApellidoUsuario));
                        cmd.Parameters.Add(new SqlParameter("@contrasena", this.Contraseña));
                        cmd.Parameters.Add(new SqlParameter("@direccion", this.Direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", this.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@email", this.Email));
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
            this.NombreUsuario = dr["nombre"] == DBNull.Value ? null : dr["nombre"].ToString();
            this.ApellidoUsuario = dr["apellido"] == DBNull.Value ? null : dr["apellido"].ToString();
            this.Contraseña = dr["contrasena"] == DBNull.Value ? null : dr["contrasena"].ToString();
            this.Telefono = dr["telefono"] == DBNull.Value ? null : dr["telefono"].ToString();
            this.Descripcion = dr["descripcion"] == DBNull.Value ? null : dr["descripcion"].ToString();
            this.Direccion = dr["direccion"] == DBNull.Value ? null : dr["direccion"].ToString();
            this.Direccion = dr["email"] == DBNull.Value ? null : dr["email"].ToString();
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
            string traercontraseñaEncriptada = "select contrasena from Usuarios where email=@email";
            {
                SqlConnection cn = null; SqlTransaction trn = null;
                if (!this.Validar()) return false;
                try
                {
                    cn = UtilidadesBD.BdSQL.Conectar();

                    //Preparar el comando
                    SqlCommand cmd = new SqlCommand(traercontraseñaEncriptada, cn);
                    cmd.Parameters.Add(new SqlParameter("@email", email));
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
        //public override string ToString()
        //{
        //    return this.Id + " - ";
        //}
        #endregion

    }
}


