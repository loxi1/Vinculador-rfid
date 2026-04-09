using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class BDPrenda
    {
        private readonly Sybase _sybase = new Sybase();
        public string ss_error = string.Empty;

        public Tuple<int, string, DataTable> ListarTimbradas(Dictionary<string, object> whereParameters)
        {
            int li_return = 0;
            string s_mensaje = string.Empty;
            DataTable tabla = new DataTable();

            if (whereParameters == null)
                whereParameters = new Dictionary<string, object>();

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new InvalidOperationException("La conexión a la base de datos no está abierta.");

                    List<string> filtros = new List<string>();
                    using (AseCommand cmd = conn.CreateCommand())
                    {
                        foreach (var item in whereParameters)
                        {
                            filtros.Add($"{item.Key} = @{item.Key}");
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                        }

                        string sql =
                            "SELECT " +
                            "linea, " +
                            "op, " +
                            "nhoja AS hoja_marcacion, " +
                            "corte, " +
                            "sub_corte AS subcorte, " +
                            "color, " +
                            "talla, " +
                            "cod_talla, " +
                            "id_talla, " +
                            "fecha, " +
                            "rfid AS id_rfid " +
                            "FROM tmp_etiq_timbradas ";

                        if (filtros.Count > 0)
                            sql += "WHERE " + string.Join(" AND ", filtros) + " ";

                        sql += "ORDER BY fecha DESC";

                        cmd.CommandText = sql;

                        using (AseDataAdapter da = new AseDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                    }

                    li_return = tabla.Rows.Count;
                    s_mensaje = li_return > 0
                        ? "Datos obtenidos correctamente."
                        : "No se encontraron timbrados.";
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en ListarTimbradas", ex);
                li_return = -1;
                s_mensaje = ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return Tuple.Create(li_return, s_mensaje, tabla);
        }

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

        public int UpdateTimbrado(
    Dictionary<string, object> whereParameters,
    Dictionary<string, object> updateParameters)
        {
            int li_return = 0;

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new InvalidOperationException("La conexión a la base de datos no está abierta.");

                    using (AseTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            if (whereParameters == null || whereParameters.Count == 0)
                                throw new Exception("whereParameters está vacío.");

                            if (updateParameters == null || updateParameters.Count == 0)
                                throw new Exception("updateParameters está vacío.");

                            List<string> setClause = new List<string>();
                            List<string> whereClause = new List<string>();

                            using (AseCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = trans;

                                foreach (var item in updateParameters)
                                {
                                    setClause.Add($"{item.Key} = @set_{item.Key}");
                                    cmd.Parameters.AddWithValue("@set_" + item.Key, item.Value ?? DBNull.Value);
                                }

                                foreach (var item in whereParameters)
                                {
                                    whereClause.Add($"{item.Key} = @where_{item.Key}");
                                    cmd.Parameters.AddWithValue("@where_" + item.Key, item.Value ?? DBNull.Value);
                                }

                                cmd.CommandText =
                                    "UPDATE tmp_etiq_timbradas " +
                                    "SET fecha = GETDATE(), " + string.Join(", ", setClause) + " " +
                                    "WHERE " + string.Join(" AND ", whereClause);

                                li_return = cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            LogError("Error en UpdateTimbrado", ex);
                            li_return = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Error general en UpdateTimbrado", ex);
                li_return = -1;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return li_return;
        }

        public Tuple<int, string, List<Dictionary<string, object>>, Dictionary<string, List<Dictionary<string, object>>>>
    VerConsolidado(Dictionary<string, object> whereParameters)
        {
            int li_return = 0;
            string s_mensaje = string.Empty;

            var datos = new DataTable();
            var totalTalla = new List<Dictionary<string, object>>();
            var detalleTalla = new Dictionary<string, List<Dictionary<string, object>>>();

            const string ESTADO_EMBALAJE = "SALIDA EMBALAJE";

            if (whereParameters == null)
                whereParameters = new Dictionary<string, object>();

            // 🔥 Corrección lógica (mejor que tu VB original)
            if (!whereParameters.ContainsKey("estado"))
                whereParameters["estado"] = ESTADO_EMBALAJE;

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new Exception("Error en conexión con Sybase.");

                    List<string> filtros = new List<string>();

                    using (AseCommand cmd = conn.CreateCommand())
                    {
                        foreach (var item in whereParameters)
                        {
                            filtros.Add($"{item.Key} = @{item.Key}");
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                        }

                        string sql =
                            "SELECT " +
                            "linea, " +
                            "op, " +
                            "color, " +
                            "talla, " +
                            "COUNT(id_timb) AS cant " +
                            "FROM tmp_etiq_timbradas ";

                        if (filtros.Count > 0)
                            sql += "WHERE " + string.Join(" AND ", filtros) + " ";

                        sql += "GROUP BY linea, op, color, talla";

                        cmd.CommandText = sql;

                        using (AseDataAdapter da = new AseDataAdapter(cmd))
                        {
                            da.Fill(datos);
                        }
                    }

                    if (datos.Rows.Count == 0)
                    {
                        li_return = 0;
                        s_mensaje = "No hay datos.";
                        return Tuple.Create(li_return, s_mensaje, totalTalla, detalleTalla);
                    }

                    Console.WriteLine("Filas: " + datos.Rows.Count);

                    // 🔹 Agrupación
                    var agrupados = new Dictionary<string, (int total, List<Dictionary<string, object>> detalles)>();

                    foreach (DataRow row in datos.Rows)
                    {
                        string linea = row["linea"].ToString();
                        string op = row["op"].ToString();
                        string color = row["color"].ToString();
                        string talla = row["talla"].ToString();
                        int cant = Convert.ToInt32(row["cant"]);

                        if (!agrupados.ContainsKey(linea))
                        {
                            agrupados[linea] = (0, new List<Dictionary<string, object>>());
                        }

                        var grupo = agrupados[linea];
                        grupo.total += cant;

                        grupo.detalles.Add(new Dictionary<string, object>
                {
                    { "op", op },
                    { "color", color },
                    { "talla", talla },
                    { "cantidad", cant }
                });

                        agrupados[linea] = grupo;
                    }

                    // 🔹 Convertir resultado
                    foreach (var item in agrupados)
                    {
                        totalTalla.Add(new Dictionary<string, object>
                {
                    { "linea", item.Key },
                    { "total", item.Value.total }
                });

                        detalleTalla[item.Key] = item.Value.detalles;
                    }

                    li_return = 1;
                    s_mensaje = "Datos obtenidos correctamente.";
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en VerConsolidado", ex);
                li_return = -1;
                s_mensaje = ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return Tuple.Create(li_return, s_mensaje, totalTalla, detalleTalla);
        }

        public DataTable GetHistorialPrenda(
    string op,
    string corte,
    string subcorte,
    string talla,
    string idTalla)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new Exception("Error en conexión con Sybase.");

                    using (AseCommand cmd = new AseCommand("USP_ACAB_EMB_MOV_PRENDAS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new AseParameter("@compania", AseDbType.VarChar)).Value = "02";
                        cmd.Parameters.Add(new AseParameter("@op", AseDbType.VarChar)).Value = op;
                        cmd.Parameters.Add(new AseParameter("@corte", AseDbType.VarChar)).Value = corte;
                        cmd.Parameters.Add(new AseParameter("@subcorte", AseDbType.VarChar)).Value = subcorte;
                        cmd.Parameters.Add(new AseParameter("@talla", AseDbType.VarChar)).Value = talla;
                        cmd.Parameters.Add(new AseParameter("@id", AseDbType.VarChar)).Value = idTalla;

                        using (AseDataReader reader = cmd.ExecuteReader())
                        {
                            tabla.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en GetHistorialPrenda", ex);
                throw;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return tabla;
        }

        public string ObtenerSubCorte(string op, string corte, string codTalla, string idTalla)
        {
            string subCorte = "";

            if (string.IsNullOrWhiteSpace(op) ||
                string.IsNullOrWhiteSpace(corte) ||
                string.IsNullOrWhiteSpace(codTalla) ||
                string.IsNullOrWhiteSpace(idTalla))
            {
                throw new ArgumentException("Los parámetros no pueden estar vacíos o nulos.");
            }

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new Exception("Error en conexión con Sybase.");

                    string query = @"
                SELECT NOrdenSubCorte
                FROM ordencortetallasid
                WHERE ccmpn = @compania
                AND nnope = @nnope
                AND nordencorte = @nordencorte
                AND cod_talla = @cod_talla
                AND id_talla = @id_talla";

                    using (AseCommand cmd = new AseCommand(query, conn))
                    {
                        cmd.Parameters.Add(new AseParameter("@compania", AseDbType.VarChar)).Value = "02";
                        cmd.Parameters.Add(new AseParameter("@nnope", AseDbType.VarChar)).Value = op;
                        cmd.Parameters.Add(new AseParameter("@nordencorte", AseDbType.VarChar)).Value = corte;
                        cmd.Parameters.Add(new AseParameter("@cod_talla", AseDbType.VarChar)).Value = codTalla;
                        cmd.Parameters.Add(new AseParameter("@id_talla", AseDbType.VarChar)).Value = idTalla;

                        using (AseDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                subCorte = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en ObtenerSubCorte", ex);
                throw;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return subCorte;
        }

        public Tuple<int, string, string> ValidarOP(Dictionary<string, object> whereParameters, string tipo)
        {
            int li_return = -1;
            string s_mensaje = string.Empty;
            string result = string.Empty;
            DataTable datos = new DataTable();

            if (whereParameters == null || whereParameters.Count == 0)
                throw new ArgumentException("El parámetro whereParameters no puede estar vacío o nulo.");

            try
            {
                using (AseConnection conn = _sybase.Connect())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                        throw new InvalidOperationException("La conexión a la base de datos no está abierta.");

                    List<string> filtros = new List<string>();
                    using (AseCommand cmd = conn.CreateCommand())
                    {
                        foreach (var item in whereParameters)
                        {
                            filtros.Add($"{item.Key} = @{item.Key}");
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                        }

                        string sql = "SELECT TOP 1 norpd, nhjmr FROM althmd ";
                        if (filtros.Count > 0)
                            sql += "WHERE " + string.Join(" AND ", filtros);

                        cmd.CommandText = sql;

                        using (AseDataReader reader = cmd.ExecuteReader())
                        {
                            datos.Load(reader);
                        }
                    }

                    if (datos.Rows.Count > 0)
                    {
                        var row = datos.Rows[0];
                        if (row[tipo] != DBNull.Value)
                        {
                            result = row[tipo].ToString();
                            li_return = 1;
                            s_mensaje = "Validación exitosa.";
                        }
                        else
                        {
                            li_return = 0;
                            s_mensaje = "No se encontró valor para el tipo solicitado.";
                        }
                    }
                    else
                    {
                        li_return = 0;
                        s_mensaje = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                LogError("Error en ValidarOP", ex);
                li_return = -1;
                s_mensaje = ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return Tuple.Create(li_return, s_mensaje, result);
        }


        private string BuildWhereClause(Dictionary<string, object> parameters, string alias = "")
        {
            if (parameters == null || parameters.Count == 0)
                throw new ArgumentException("Parámetros vacíos");

            return string.Join(" AND ", parameters.Keys.Select(key =>
                string.IsNullOrEmpty(alias)
                    ? $"{key} = @{key}"
                    : $"{alias}.{key} = @{key}"
            ));
        }

        public Tuple<int, List<Dictionary<string, object>>, Dictionary<string, List<Dictionary<string, object>>>>
BuscarHMDetalle(Dictionary<string, object> whereParameters)
        {
            var datos = new DataTable();
            var totalTalla = new List<Dictionary<string, object>>();
            var detalleTalla = new Dictionary<string, List<Dictionary<string, object>>>();

            try
            {
                string where = BuildWhereClause(whereParameters, "alt");

                string query = $@"
            SELECT 
                alt.cclrcl,
                alt.tclrcl,
                alt.qartsl,
                alw.tcrct6
            FROM althmd alt
            LEFT JOIN almart alm ON alm.ctpar = alt.ctpar AND alm.cartc = alt.cartc
            LEFT JOIN alwart alw ON alm.ctpar = alw.ctpar AND alm.cartc = alw.cartc
            WHERE {where}
            ORDER BY alt.cclrcl, alw.tcrct6
        ";

                using (var connectionAse = _sybase.Connect())
                {
                    if (connectionAse == null || connectionAse.State != ConnectionState.Open)
                        throw new Exception("Error en conexión con la base de datos.");

                    using (var comando = new AseCommand(query, connectionAse))
                    {
                        foreach (var param in whereParameters)
                        {
                            comando.Parameters.AddWithValue("@" + param.Key, param.Value);
                        }

                        using (var reader = comando.ExecuteReader())
                        {
                            datos.Load(reader);
                        }
                    }
                }

                if (datos.Rows.Count == 0)
                    return Tuple.Create(0, totalTalla, detalleTalla);

                var agrupados = new Dictionary<string, (string desc, int total, List<Dictionary<string, object>> det)>();

                foreach (DataRow row in datos.Rows)
                {
                    string color = row["cclrcl"].ToString();
                    string desc = row["tclrcl"].ToString();
                    int cant = Convert.ToInt32(row["qartsl"]);
                    string talla = row["tcrct6"].ToString();

                    if (!agrupados.ContainsKey(color))
                        agrupados[color] = (desc, 0, new List<Dictionary<string, object>>());

                    var g = agrupados[color];
                    g.total += cant;

                    g.det.Add(new Dictionary<string, object>
            {
                { "talla", talla },
                { "cantidad", cant }
            });

                    agrupados[color] = g;
                }

                foreach (var g in agrupados)
                {
                    totalTalla.Add(new Dictionary<string, object>
            {
                { "cclrcl", g.Key },
                { "tclrcl", g.Value.desc },
                { "total", g.Value.total }
            });

                    detalleTalla[g.Key] = g.Value.det;
                }

                return Tuple.Create(1, totalTalla, detalleTalla);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error BuscarHMDetalle: " + ex.Message);
                return Tuple.Create(0, totalTalla, detalleTalla);
            }
        }

        public DataTable BuscarHMCabecera(Dictionary<string, object> whereParameters)
        {
            var datos = new DataTable();

            try
            {
                string where = BuildWhereClause(whereParameters, "althmc");

                string query = $@"
            SELECT 
                althmc.norpd,
                althmc.nhjmr,
                althmc.cclnt,
                althmc.npocl,
                CONVERT(VARCHAR, althmc.fentr, 105) AS fentr
            FROM althmc
            INNER JOIN altopc ON althmc.norpd = altopc.nnope
            WHERE {where}
            ORDER BY althmc.norpd, althmc.nhjmr
        ";

                using (var conn = _sybase.Connect())
                using (var cmd = new AseCommand(query, conn))
                {
                    foreach (var p in whereParameters)
                        cmd.Parameters.AddWithValue("@" + p.Key, p.Value);

                    using (var reader = cmd.ExecuteReader())
                        datos.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error BuscarHMCabecera: " + ex.Message);
            }

            return datos;
        }

    }
}
