
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AJSProjectTemplate.BL.Based;
using AJSProjectTemplate.DataTransferObject.Dto;
using AJSProjectTemplates.DL.SQLEngine;

namespace AJSProjectTemplate.BL.BusinessEngine
{
    public class CustomerBusinessEngine : IWrite<CustomerDto>
    {
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> SaveWithIEnumerableOutput(CustomerDto dto)
        {
            var customer = new CustomerDbEngine();
            return  customer.SaveWithIEnumerableOutput(dto);

        }

        public IQueryable<CustomerDto> SaveWithIQueryableOutput(CustomerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
