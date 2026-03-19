using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class Sybase
    {
        private AseConnection myConexion;
        private readonly string m_Usuario = "corporativo";
        private readonly string m_Password = "c0rp0r@t1v0";
        private string m_ServerName = "";
        private string m_Port = "";
        private string m_DataBase = "";
        public string s_error = "";

        // Método para conectarse a la base de datos
        public AseConnection Connect()
        {
            try
            {
                // Cargar configuración
                if (!LoadConfig("tsconfig.json"))
                {
                    throw new Exception("Error al cargar la configuración. Verifique el archivo tsconfig.json.");
                }

                // Crear la conexión si es necesario
                if (myConexion == null || myConexion.State == ConnectionState.Closed || myConexion.State == ConnectionState.Broken)
                {
                    string sCadenaConexion = $"Data Source={m_ServerName};Port={m_Port};Database={m_DataBase};Uid={m_Usuario};Pwd={m_Password};";
                    //Console.WriteLine($"Cadena de conexión generada: {sCadenaConexion}");

                    myConexion = new AseConnection(sCadenaConexion);
                    myConexion.Open();
                }
            }
            catch (AseException ex)
            {
                s_error = $"Error al conectar: {ex.Message}";
                LogError("Error al conectar", ex);
                throw;
            }

            Console.WriteLine($"Estado de la conexión después de intentar abrir: {myConexion.State}");
            return myConexion;
        }

        // Método para desconectarse de la base de datos
        public int Disconnect()
        {
            try
            {
                if (myConexion != null && myConexion.State == ConnectionState.Open)
                {
                    myConexion.Close();
                }
            }
            catch (AseException ex)
            {
                s_error = ex.Message;
                LogError("Error al cerrar la conexión a la base de datos", ex);
            }
            return 1;
        }

        // Método para obtener errores
        public string GetError()
        {
            return s_error;
        }

        // Método para registrar errores en un log
        private void LogError(string message, Exception ex = null)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            if (ex != null)
            {
                logMessage += Environment.NewLine + ex.ToString();
            }

            File.AppendAllText("db_errors.log", logMessage + Environment.NewLine);
        }

        // Método para cargar configuración desde un archivo JSON
        private bool LoadConfig(string filePath)
        {
            try
            {
                // Obtener el directorio base de ejecución
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // Subir dos niveles para llegar a "bin"
                string binDirectory = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;
                // Construir la ruta del archivo tsconfig.json
                string iniDirectory = Path.Combine(binDirectory, "Ini");
                string configPath = Path.Combine(iniDirectory, filePath);

                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                    if (config.ContainsKey("SERVER_NAME_SY")) m_ServerName = config["SERVER_NAME_SY"];
                    if (config.ContainsKey("PORT_SY")) m_Port = config["PORT_SY"];
                    if (config.ContainsKey("DATA_BASE_SY")) m_DataBase = config["DATA_BASE_SY"];

                    if (string.IsNullOrEmpty(m_ServerName) || string.IsNullOrEmpty(m_Port) || string.IsNullOrEmpty(m_DataBase))
                    {
                        s_error = "Faltan parámetros en el archivo de configuración.";
                        Console.WriteLine(s_error);
                        return false;
                    }

                    return true;
                }
                else
                {
                    s_error = $"El archivo de configuración no existe: {filePath}";
                    Console.WriteLine(s_error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                s_error = $"Error al cargar configuración: {ex.Message}";
                Console.WriteLine(s_error);
                return false;
            }
        }
    }
}
