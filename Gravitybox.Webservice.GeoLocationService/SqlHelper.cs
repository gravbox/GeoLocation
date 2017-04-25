using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Gravitybox.Webservice.GeoLocationService
{
    internal class SqlHelper
    {
        internal static DataSet GetDataset(string connectionString, string sql, List<SqlParameter> parameters = null)
        {
            const int MAX_TRY = 5;
            var tryCount = 0;

            if (parameters == null) parameters = new List<SqlParameter>();
            var builder = new SqlConnectionStringBuilder(connectionString);
            using (var command = new SqlCommand())
            {
                //Declare outside of try/catch so parameters are only added once to a collection (causes an error if loop more than once)
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters.ToList().Cast<ICloneable>().ToList().Select(x => x.Clone()).Cast<SqlParameter>().ToArray());
                command.CommandTimeout = builder.ConnectTimeout;

                do
                {
                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            command.Connection = connection;
                            var da = new SqlDataAdapter { SelectCommand = command };
                            var ds = new DataSet();
                            da.Fill(ds);
                            return ds;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (tryCount < MAX_TRY)
                        {
                            Thread.Sleep(100);
                            tryCount++;
                        }
                        else
                        {
                            throw;
                        }
                    }
                } while (true);
            }
        }
    }
}