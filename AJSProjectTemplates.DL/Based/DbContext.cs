using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace AJSProjectTemplates.DL.Based
{
    public abstract class DbContext<TDto> 
    {
        protected string ConnectionString { get; set; }
        protected DbContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        protected abstract List<SqlParameter> SetupParameters(TDto dto);

        protected SqlDataReader ExecuteSqlDataReader(string spName, TDto dto)
        {
            
            SqlDataReader reader = null;
           var parameters = SetupParameters(dto);

            using (var objConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(spName, objConnection) {CommandType = CommandType.StoredProcedure})
                {
                    using (var transaction = objConnection.BeginTransaction("StartTransaction"))
                    {
                        cmd.Connection = objConnection;
                        cmd.Transaction = transaction;
                        try
                        {

                            foreach (var param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                            reader = cmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                    
                       
                }
            }
            return reader;
        }
       
    }
}