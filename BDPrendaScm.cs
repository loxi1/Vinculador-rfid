using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DS9908R_App
{
    public class BDPrendaScm
    {
        private readonly MySQLconexion _mysql = new MySQLconexion();

        public long Insert(Dictionary<string, object> data)
        {
            using (var conn = _mysql.Connect())
            {
                var columns = string.Join(",", data.Keys);
                var parameters = string.Join(",", data.Keys.Select(k => "@" + k));

                string sql = $"INSERT INTO prenda ({columns}) VALUES ({parameters})";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    foreach (var kv in data)
                        cmd.Parameters.AddWithValue("@" + kv.Key, kv.Value ?? "");

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
