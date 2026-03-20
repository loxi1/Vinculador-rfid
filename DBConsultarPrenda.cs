using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DS9908R_App
{
    public class DBConsultarPrenda
    {
        private readonly MySQLconexion _mysql = new MySQLconexion();

        public DataTable BuscarPorCodigo(string codigo)
        {
            using (var conn = _mysql.Connect())
            {
                string sql = "SELECT * FROM prenda WHERE id_barras = @codigo";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (var da = new MySqlDataAdapter(cmd))
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
