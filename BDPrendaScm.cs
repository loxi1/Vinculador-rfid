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
        public long Insert(Dictionary<string, object> data)
        {
            using (var conn = MySQLconexion.GetConnection())
            {
                conn.Open();

                var columns = string.Join(",", data.Keys);
                var parameters = string.Join(",", data.Keys.Select(k => "@" + k));

                string sql = $"INSERT INTO prenda ({columns}) VALUES ({parameters})";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    foreach (var kv in data)
                        cmd.Parameters.AddWithValue("@" + kv.Key, kv.Value);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
