using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DS9908R_App
{
    public class DBConsultarPrenda
    {
        private readonly MySQLconexion _mysql = new MySQLconexion();
        public string ss_error = string.Empty;

        public DataTable BuscarPorCodigo(string codigo)
        {
            return Buscar("SELECT * FROM prenda WHERE id_barras = @valor ORDER BY fecha DESC", codigo);
        }

        public DataTable BuscarPorRfid(string rfid)
        {
            return Buscar("SELECT * FROM prenda WHERE id_rfid = @valor ORDER BY fecha DESC", rfid);
        }

        public DataTable BuscarPorOp(string op)
        {
            return Buscar("SELECT * FROM prenda WHERE op = @valor ORDER BY fecha DESC", op);
        }

        private DataTable Buscar(string sql, string valor)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = _mysql.Connect())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                throw;
            }
            finally
            {
                _mysql.Disconnect();
            }

            return dt;
        }
    }
}