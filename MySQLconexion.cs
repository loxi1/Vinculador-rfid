using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace DS9908R_App
{
    public class MySQLconexion
    {
        private MySqlConnection myConexion;
        private string m_ServerName = "";
        private string m_Port = "";
        private string m_Database = "";
        private string m_Usuario = "";
        private string m_Password = "";
        private string m_ConnectionLifetime = "300";

        public string s_error = "";

        public MySqlConnection Connect()
        {
            try
            {
                if (!LoadConfig("tsconfig.json"))
                    throw new Exception("No se pudo cargar la configuración MySQL.");

                if (myConexion == null ||
                    myConexion.State == ConnectionState.Closed ||
                    myConexion.State == ConnectionState.Broken)
                {
                    string connStr =
                        $"Server={m_ServerName};" +
                        $"Port={m_Port};" +
                        $"Database={m_Database};" +
                        $"Uid={m_Usuario};" +
                        $"Pwd={m_Password};" +
                        $"Connection Lifetime={m_ConnectionLifetime};";

                    myConexion = new MySqlConnection(connStr);
                    myConexion.Open();
                }

                return myConexion;
            }
            catch (Exception ex)
            {
                s_error = ex.Message;
                throw;
            }
        }

        public int Disconnect()
        {
            try
            {
                if (myConexion != null && myConexion.State == ConnectionState.Open)
                    myConexion.Close();
            }
            catch (Exception ex)
            {
                s_error = ex.Message;
            }

            return 1;
        }

        public string GetError()
        {
            return s_error;
        }

        private bool LoadConfig(string filePath)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string binDirectory = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;
                string iniDirectory = Path.Combine(binDirectory, "Ini");
                string configPath = Path.Combine(iniDirectory, filePath);

                if (!File.Exists(configPath))
                {
                    s_error = "No existe el archivo: " + configPath;
                    return false;
                }

                string json = File.ReadAllText(configPath);
                var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                if (config.ContainsKey("DB_SERVER_MY")) m_ServerName = config["DB_SERVER_MY"];
                if (config.ContainsKey("DB_PORT_MY")) m_Port = config["DB_PORT_MY"];
                if (config.ContainsKey("DB_NAME_MY")) m_Database = config["DB_NAME_MY"];
                if (config.ContainsKey("DB_USER_MY")) m_Usuario = config["DB_USER_MY"];
                if (config.ContainsKey("DB_PASSWORD_MY")) m_Password = config["DB_PASSWORD_MY"];
                if (config.ContainsKey("Connection Lifetime")) m_ConnectionLifetime = config["Connection Lifetime"];

                return !string.IsNullOrWhiteSpace(m_ServerName)
                    && !string.IsNullOrWhiteSpace(m_Port)
                    && !string.IsNullOrWhiteSpace(m_Database)
                    && !string.IsNullOrWhiteSpace(m_Usuario)
                    && !string.IsNullOrWhiteSpace(m_Password);
            }
            catch (Exception ex)
            {
                s_error = ex.Message;
                return false;
            }
        }
    }
}