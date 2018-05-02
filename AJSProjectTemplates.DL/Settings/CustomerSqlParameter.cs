using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AJSProjectTemplate.DataTransferObject.Dto;


namespace AJSProjectTemplates.DL.Settings
{
    public static class CustomerSqlParameter
    {
        public static List<SqlParameter> usp_CustomerInsertParamaters(this CustomerDto dto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Size = 150, Value = dto.FirstName},
                new SqlParameter("@LastName", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Size = 150, Value = dto.LastName}
            };
            return parameters;
        }
    }
   
}
