using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class BDPrenda
    {
        private readonly Sybase _sybase = new Sybase();
        public string ss_error = string.Empty;

        public Tuple<int, string> SaveRFID(
            string sCodBarra,
            string sCompania,
            string sCodTrabajador,
            string sIDRfid,
            string nHoja)
        {
            int li_return = -1;
            string s_mensaje = string.Empty;
            DataTable tabla = new DataTable();

            try
            {
                if (sIDRfid == null) sIDRfid = string.Empty;
                sIDRfid = sIDRfid.Trim().Replace(" ", "");
                if (sIDRfid.Length > 24)
                {
                    sIDRfid = sIDRfid.Substring(sIDRfid.Length - 24);
                }
                System.Diagnostics.Debug.WriteLine("codBarras"+sCodBarra+" compania->"+ sCompania+" codigo->"+ sCodTrabajador+ " rfid->"+ sIDRfid);
                using (AseConnection connectionAse = _sybase.Connect())
                {
                    if (connectionAse == null || connectionAse.State != ConnectionState.Open)
                    {
                        throw new Exception("Error en conexión con la base de datos Sybase.");
                    }

                    using (AseTransaction trans = connectionAse.BeginTransaction())
                    {
                        try
                        {
                            using (AseCommand command = new AseCommand("USP_SAL_EMB_CON_RFID", connectionAse, trans))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.Add(new AseParameter("@etqt", AseDbType.VarChar)).Value = sCodBarra;
                                command.Parameters.Add(new AseParameter("@empresa", AseDbType.VarChar)).Value = sCompania;
                                command.Parameters.Add(new AseParameter("@usr", AseDbType.VarChar)).Value = sCodTrabajador;
                                command.Parameters.Add(new AseParameter("@rfid", AseDbType.VarChar)).Value = sIDRfid;
                                command.Parameters.Add(new AseParameter("@nHoja", AseDbType.VarChar)).Value = nHoja ?? "";

                                using (AseDataReader reader = command.ExecuteReader())
                                {
                                    tabla.Load(reader);
                                }
                            }

                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }

                if (tabla.Rows.Count > 0)
                {
                    li_return = Convert.ToInt32(tabla.Rows[0]["codigo"]);
                    s_mensaje = tabla.Columns.Contains("mensaje")
                        ? Convert.ToString(tabla.Rows[0]["mensaje"])
                        : string.Empty;
                }
                else
                {
                    li_return = -1;
                    s_mensaje = "El procedimiento no devolvió datos.";
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en SaveRFID", ex);
                li_return = -1;
                s_mensaje = ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return Tuple.Create(li_return, s_mensaje);
        }

        public DataTable GetTimbradasByWorkerAndEtiqueta(string codTrabajador, string etiqueta)
        {
            DataTable dt = new DataTable();
            const string sql =
                "SELECT etiqueta, op, corte, sub_corte, cod_talla, id_talla, talla, fotocheck, linea, fecha, color, cod_comb, rfid, nhoja " +
                "FROM tmp_etiq_timbradas " +
                "WHERE fotocheck = @worker AND etiqueta = @etiqueta " +
                "ORDER BY fecha DESC";

            try
            {
                using (AseConnection conn = _sybase.Connect())
                using (AseCommand cmd = new AseCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@worker", codTrabajador);
                    cmd.Parameters.AddWithValue("@etiqueta", etiqueta);

                    using (AseDataAdapter da = new AseDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en GetTimbradasByWorkerAndEtiqueta", ex);
                throw;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return dt;
        }

        public int NuevoTimbrado(Dictionary<string, object> whereParameters)
        {
            int rowsAffected = 0;

            try
            {
                List<string> whereClause = new List<string>();
                foreach (KeyValuePair<string, object> item in whereParameters)
                {
                    whereClause.Add(item.Key + " = @" + item.Key);
                }

                string sql = "DELETE FROM tmp_etiq_timbradas";
                if (whereClause.Count > 0)
                {
                    sql += " WHERE " + string.Join(" AND ", whereClause.ToArray());
                }

                using (AseConnection conn = _sybase.Connect())
                using (AseCommand cmd = new AseCommand(sql, conn))
                {
                    foreach (KeyValuePair<string, object> item in whereParameters)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                    }

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en NuevoTimbrado", ex);
                rowsAffected = -1;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return rowsAffected;
        }

        private void LogError(string message, Exception ex)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bdprenda_errors.log");
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine + ex + Environment.NewLine;
                File.AppendAllText(path, text);
            }
            catch
            {
            }
        }
    }
}