using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AJSProjectTemplates.DL.Based;
using AJSProjectTemplate.DataTransferObject.Dto;
using AJSProjectTemplates.DL.ObjectMapping;
using AJSProjectTemplates.DL.Settings;

namespace AJSProjectTemplates.DL.SQLEngine
{
    public class CustomerDbEngine : DbContext<CustomerDto>, ISqlWriter<CustomerDto>
    {
        #region Method
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        protected override List<SqlParameter> SetupParameters(CustomerDto dto)
        {
            return dto.usp_CustomerInsertParamaters();
        }
        public IEnumerable<CustomerDto> SaveWithIEnumerableOutput(CustomerDto dto)
        {
            var reader = ExecuteSqlDataReader("spName1", dto);
            var output = new List<CustomerDto>();
            using (reader)
            {
                while (reader.Read())
                {
                    var customer = reader.MapCustomer();
                    output.Add(customer);
                }
            }
            return output;
        }

        public IQueryable<CustomerDto> SaveWithIQueryableOutput(CustomerDto dto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
