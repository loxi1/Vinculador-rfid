using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS9908R_App
{
    public class DBConsultarPrenda
    {
        public DataTable BuscarPorCodigo(string codigo)
        {
            using (var conn = MySQLconexion.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM prenda WHERE id_barras = @codigo";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
