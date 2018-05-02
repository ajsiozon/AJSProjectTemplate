using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AJSProjectTemplates.DL.SQLEngine;
using AJSProjectTemplates.DL.Based;
using AJSProjectTemplate.DataTransferObject.Dto;

namespace AJSProjectTemplates.DL.ObjectMapping
{
    public static class DataMapping
    {
        //public static void MapValue<TModel, TValue>(this SqlDataReader reader, TModel target,
        //   Expression<Func<TModel, TValue>> expression, string privateKey = null, string prefix = null)
        //{

        public static CustomerDto MapCustomer(this SqlDataReader reader, string privateKey = null)
        {
            var model = new CustomerDto();
            reader.MapValue(model, x => x.CustomerId, privateKey);
            return model;
        }

    }
}
