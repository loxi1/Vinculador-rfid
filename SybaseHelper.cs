using System;
using System.Collections.Generic;
using System.Data;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class SybaseHelper
    {
        private readonly Sybase sybase = new Sybase(); // Instancia de la clase Sybase para manejar la conexión
        private string errorMessage; // Para almacenar errores

        // Método para validar usuario en la base de datos
        public DataRow ValidateUser(string codigo, string claveEncriptada)
        {
            string query = "SELECT identificador, codigo, datos, empresa, estado, clave, turno " +
                           "FROM usuario_timbrado WHERE codigo = @codigo AND clave = @clave";
            DataTable result = new DataTable();

            try
            {
                // Establecer conexión
                AseConnection connection = sybase.Connect();

                // Configurar comando SQL
                using (AseCommand command = new AseCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@clave", claveEncriptada);

                    // Ejecutar consulta
                    using (AseDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader); // Cargar los resultados en un DataTable
                    }
                }

                // Cerrar conexión
                sybase.Disconnect();
            }
            catch (Exception ex)
            {
                errorMessage = $"Error al validar usuario: {ex.Message}";
                sybase.Disconnect();
            }

            // Retornar la primera fila si existe, de lo contrario null
            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }

        // Método para validar usuario basado en un diccionario de parámetros
        public DataTable ValidateUser(Dictionary<string, object> whereParameters)
        {
            DataTable result = new DataTable();

            try
            {
                // Construir la consulta dinámica
                string query = "SELECT identificador, codigo, datos, empresa, estado, clave, turno FROM usuario_timbrado";
                List<string> whereClause = new List<string>();

                foreach (var param in whereParameters)
                {
                    whereClause.Add($"{param.Key} = @{param.Key}");
                }

                if (whereClause.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", whereClause);
                }

                Console.WriteLine($"Query->{query}");

                // Establecer conexión
                AseConnection connection = sybase.Connect();

                // Configurar comando SQL
                using (AseCommand command = new AseCommand(query, connection))
                {
                    foreach (var param in whereParameters)
                    {
                        command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                    }

                    using (AseDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }

                sybase.Disconnect();
            }
            catch (Exception ex)
            {
                errorMessage = $"Error al validar usuario: {ex.Message}";
                sybase.Disconnect();
            }

            return result;
        }

        // Método para actualizar la contraseña
        public int UpdatePassword(string codigo, string claveEncriptada)
        {
            string query = "UPDATE usuario_timbrado SET clave = @clave WHERE codigo = @codigo";
            int rowsAffected = 0;

            try
            {
                AseConnection connection = sybase.Connect();

                using (AseCommand command = new AseCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@clave", claveEncriptada);

                    rowsAffected = command.ExecuteNonQuery();
                }

                sybase.Disconnect();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                errorMessage = $"Error al actualizar la contraseña: {ex.Message}";
                sybase.Disconnect();
                return -1; // Indica que ocurrió un error
            }
        }

        // Método para obtener errores
        public string GetLastError()
        {
            return !string.IsNullOrEmpty(errorMessage) ? errorMessage : sybase.GetError();
        }
    }
}
