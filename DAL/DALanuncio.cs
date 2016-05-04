using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;


namespace DAL
{
    class DALanuncio:DALBase
    {
        public static SqlDataReader select_All()
        {
            string StoredProcedure = "SELECT_ALL_ANUNCIOS";
            SqlDataReader dr = select(null, StoredProcedure, CommandType.StoredProcedure);
            return dr;
        }




        public static SqlDataReader select_byId(int id)
        {

            SqlParameter param = new SqlParameter();
            param.Value = id;
            param.ParameterName = "Id"; ;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            string StoreProcedure = "SELECT_ANUNCIOSById";
            SqlDataReader dr = select(parameters, StoreProcedure, CommandType.StoredProcedure);
            return dr;
        }
    }

}
