using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AJSProjectTemplate.Common.Security;

namespace AJSProjectTemplates.DL.ObjectMapping
{
    public static class SqlCommonHelper
    {
        public static void AddWithValue<TModel, TValue>(this SqlParameterCollection parameters, TModel target,
            Expression<Func<TModel, TValue>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return;

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                return;

            var func = expression.Compile();
            var value = func(target);
            parameters.AddWithValue("@" + property.Name, (object)value ?? DBNull.Value);
        }

        public static void AddWithHashedValue(this SqlParameterCollection parameters, string parameterName, string value)
        {
            parameters.AddWithValue(parameterName,
                string.IsNullOrWhiteSpace(value) ? SqlString.Null :
                    Encryptor.Encrypt(value.Trim().ToLower()));
        }

        public static void AddWithNullableValue<TValue>(this SqlParameterCollection parameters, string parameterName, TValue value)
        {
            parameters.AddWithValue(parameterName, (object)value ?? DBNull.Value);
        }

        public static void MapValue<TModel, TValue>(this SqlDataReader reader, TModel target,
            Expression<Func<TModel, TValue>> expression, string privateKey = null, string prefix = null)
        {
            try
            {
                var memberExpression = expression.Body as MemberExpression;
                if (memberExpression == null)
                    return;

                var property = memberExpression.Member as PropertyInfo;
                if (property == null)
                    return;

                var column = (prefix ?? "") + property.Name;
                TValue value = reader[column] == DBNull.Value ? default(TValue) : (TValue)reader[column];
                if (privateKey == null || value == null)
                {
                    property.SetValue(target, value, null);
                }
                else
                {
                    try
                    {
                        var strValue = Encryptor.Decrypt(privateKey, (value as string));
                        property.SetValue(target, strValue, null);
                    }
                    catch (Exception)
                    {
                        // decryption failed, if improperly encrypted, return null
                        var strValue = (value as string);
                        property.SetValue(target, strValue.Length > 50 && !strValue.Contains(" ") ? null : strValue, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void MapValue<TModel, TValue>(this DataRow row, TModel target,
            Expression<Func<TModel, TValue>> expression, string privateKey = null, string prefix = null)
        {
            try
            {
                var memberExpression = expression.Body as MemberExpression;
                if (memberExpression == null)
                    return;

                var property = memberExpression.Member as PropertyInfo;
                if (property == null)
                    return;

                var column = (prefix ?? "") + property.Name;
                TValue value = row[column] == DBNull.Value ? default(TValue) : (TValue)row[column];
                if (privateKey == null || value == null)
                {
                    property.SetValue(target, value, null);
                }
                else
                {
                    try
                    {
                        var strValue = Encryptor.Decrypt(privateKey, (value as string));
                        property.SetValue(target, strValue, null);
                    }
                    catch (Exception)
                    {
                        // decryption failed, if improperly encrypted, return null
                        var strValue = (value as string);
                        property.SetValue(target, strValue.Length > 50 && !strValue.Contains(" ") ? null : strValue, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }
    }
}
