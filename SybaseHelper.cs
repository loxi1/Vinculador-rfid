using System;
using System.Collections.Generic;
using System.Data;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class SybaseHelper
    {
        private readonly Sybase _sybase = new Sybase();
        private string _errorMessage = string.Empty;

        public static AseConnection GetConnection()
        {
            Sybase sybase = new Sybase();
            return sybase.Connect();
        }

        public DataRow ValidateUser(string codigo, string claveEncriptada)
        {
            DataTable result = new DataTable();
            const string query =
                "SELECT identificador, codigo, datos, empresa, estado, clave, turno " +
                "FROM usuario_timbrado " +
                "WHERE codigo = @codigo AND clave = @clave";

            try
            {
                using (AseConnection connection = _sybase.Connect())
                using (AseCommand command = new AseCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@clave", claveEncriptada);

                    using (AseDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "Error al validar usuario: " + ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }

        public DataTable ValidateUser(Dictionary<string, object> whereParameters)
        {
            DataTable result = new DataTable();

            try
            {
                string query =
                    "SELECT identificador, codigo, datos, empresa, estado, clave, turno " +
                    "FROM usuario_timbrado";

                List<string> whereClause = new List<string>();
                foreach (KeyValuePair<string, object> param in whereParameters)
                {
                    whereClause.Add(param.Key + " = @" + param.Key);
                }

                if (whereClause.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", whereClause.ToArray());
                }

                using (AseConnection connection = _sybase.Connect())
                using (AseCommand command = new AseCommand(query, connection))
                {
                    foreach (KeyValuePair<string, object> param in whereParameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
                    }

                    using (AseDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "Error al validar usuario: " + ex.Message;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return result;
        }

        public int UpdatePassword(string codigo, string claveEncriptada)
        {
            int rowsAffected = 0;
            const string query = "UPDATE usuario_timbrado SET clave = @clave WHERE codigo = @codigo";

            try
            {
                using (AseConnection connection = _sybase.Connect())
                using (AseCommand command = new AseCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@clave", claveEncriptada);
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "Error al actualizar la contraseña: " + ex.Message;
                rowsAffected = -1;
            }
            finally
            {
                _sybase.Disconnect();
            }

            return rowsAffected;
        }

        public string GetLastError()
        {
            return !string.IsNullOrWhiteSpace(_errorMessage) ? _errorMessage : _sybase.GetError();
        }
    }
}