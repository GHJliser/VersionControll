using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System.Data.Common;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AP.Dao
{
    public class DatabaseHelper
    {
        public static IEnumerable<Tout> Query<Tin, Tout>(string spName, Tin query)
        {
            using var client = GetClient();
            return client.Query<Tout>(CombineSpName(spName), param: query, commandType: CommandType.StoredProcedure);
        }

        public static void Insert<Tin>(string spName, Tin model)
        {
            using var client = GetClient();
            var rowCount = client.Execute(CombineSpName(spName), param: GetParameters(model), commandType: CommandType.StoredProcedure);
        }

        private static DynamicParameters GetParameters<T>(T model)
        {
            var para = new DynamicParameters();
            foreach (var item in typeof(T).GetProperties())
            {
                if (!item.HasAttribute<AP.Model.BO.DbParameterAttribute>())
                {
                    continue;
                }
                para.Add("@" + item.Name, item.GetValue(model));
            }
            return para;
        }

        private static IDbConnection GetClient()
        {
            var connStr = "Server=.\\SQLEXPRESS2014;Database=DemoDB;Integrated Security = True;";
            return new System.Data.SqlClient.SqlConnection(connStr);
        }

        private static string CombineSpName(string simple)
            => $"[Demo].[{simple}]";
    }
}
