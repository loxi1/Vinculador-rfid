using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class BDPrenda
    {
        public Tuple<int, string> SaveRFID(
            string codigoBarra,
            string empresa,
            string trabajador,
            string rfid,
            string hojaMarcacion)
        {
            try
            {
                using (var conn = SybaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "USP_SAL_EMB_CON_RFID";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                        cmd.Parameters.AddWithValue("@Empresa", empresa);
                        cmd.Parameters.AddWithValue("@Trabajador", trabajador);
                        cmd.Parameters.AddWithValue("@RFID", rfid);
                        cmd.Parameters.AddWithValue("@HojaMarcacion", hojaMarcacion);

                        cmd.ExecuteNonQuery();
                    }
                }

                return Tuple.Create(0, "OK");
            }
            catch (Exception ex)
            {
                return Tuple.Create(1, ex.Message);
            }
        }

        public DataTable GetTimbradasByWorkerAndEtiqueta(string worker, string etiqueta)
        {
            using (var conn = SybaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT * 
                    FROM tmp_etiq_timbradas 
                    WHERE fotocheck = @worker 
                    AND etiqueta = @etiqueta";

                    cmd.Parameters.AddWithValue("@worker", worker);
                    cmd.Parameters.AddWithValue("@etiqueta", etiqueta);

                    using (var da = new Sybase.Data.AseClient.AseDataAdapter(cmd))
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
