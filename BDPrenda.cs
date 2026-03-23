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
        private readonly Sybase _sybase = new Sybase();

        public Tuple<int, string> SaveRFID(
            string codigoBarra,
            string empresa,
            string trabajador,
            string rfid,
            string hojaMarcacion)
        {
            try
            {
                using (var conn = _sybase.Connect())
                {
                    System.Diagnostics.Debug.WriteLine("Conexión abierta a Sybase.");
                    using (var cmd = new AseCommand("USP_SAL_EMB_CON_RFID", conn))
                    {
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
            using (var conn = _sybase.Connect())
            {
                using (var cmd = new AseCommand(
                    @"SELECT * 
                      FROM tmp_etiq_timbradas 
                      WHERE fotocheck = @worker 
                      AND etiqueta = @etiqueta", conn))
                {
                    cmd.Parameters.AddWithValue("@worker", worker);
                    cmd.Parameters.AddWithValue("@etiqueta", etiqueta);

                    using (var da = new AseDataAdapter(cmd))
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
