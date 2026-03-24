using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DS9908R_App
{
    public class BDPrendaScm
    {
        private readonly MySQLconexion _conexion = new MySQLconexion();
        public string ss_error = string.Empty;

        public long Insert(Dictionary<string, object> columns)
        {
            long ll_return = 0;

            try
            {
                using (MySqlConnection connection = _conexion.Connect())
                {
                    string tableName = "`prenda`";
                    string columnNames = string.Join(", ", columns.Keys.Select(delegate (string key) { return "`" + key + "`"; }).ToArray());
                    string parameterNames = string.Join(", ", columns.Keys.Select(delegate (string key) { return "@" + key; }).ToArray());

                    string sql = "INSERT INTO " + tableName + " (" + columnNames + ") VALUES (" + parameterNames + ")";

                    using (MySqlCommand comando = new MySqlCommand(sql, connection))
                    {
                        foreach (KeyValuePair<string, object> param in columns)
                        {
                            comando.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
                        }

                        ll_return = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en Insert", ex);
                ll_return = -1;
            }
            finally
            {
                _conexion.Disconnect();
            }

            return ll_return;
        }

        public string GetError()
        {
            return ss_error;
        }

        private void LogError(string message, Exception ex)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bdprendascm_errors.log");
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine + ex + Environment.NewLine;
                File.AppendAllText(path, text);
            }
            catch
            {
            }
        }
    }
}