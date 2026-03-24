using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Sybase.Data.AseClient;

namespace DS9908R_App
{
    public class Sybase
    {
        private AseConnection _connection;
        private string _serverName = "";
        private string _port = "";
        private string _database = "";
        private string _user = "corporativo";
        private string _password = "c0rp0r@t1v0";

        public string LastError { get; private set; }

        public AseConnection Connect()
        {
            try
            {
                LoadConfig();

                string connectionString =
                    string.Format(
                        "Data Source={0};Port={1};Database={2};Uid={3};Pwd={4};",
                        _serverName,
                        _port,
                        _database,
                        _user,
                        _password);

                if (_connection == null)
                {
                    _connection = new AseConnection(connectionString);
                }
                else if (!string.Equals(_connection.ConnectionString, connectionString, StringComparison.OrdinalIgnoreCase))
                {
                    SafeClose();
                    _connection = new AseConnection(connectionString);
                }

                if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                {
                    _connection.Open();
                }

                return _connection;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                LogError("Error al conectar a Sybase", ex);
                throw;
            }
        }

        public void Disconnect()
        {
            SafeClose();
        }

        public string GetError()
        {
            return LastError ?? string.Empty;
        }

        private void LoadConfig()
        {
            Dictionary<string, string> config = DBConsultas.LoadJsonConfig("tsconfig.json");

            _serverName = config.ContainsKey("SERVER_NAME_SY") ? config["SERVER_NAME_SY"] : "";
            _port = config.ContainsKey("PORT_SY") ? config["PORT_SY"] : "";
            _database = config.ContainsKey("DATA_BASE_SY") ? config["DATA_BASE_SY"] : "";

            if (config.ContainsKey("DB_USER_SY") && !string.IsNullOrWhiteSpace(config["DB_USER_SY"]))
                _user = config["DB_USER_SY"];

            if (config.ContainsKey("DB_PASSWORD_SY") && !string.IsNullOrWhiteSpace(config["DB_PASSWORD_SY"]))
                _password = config["DB_PASSWORD_SY"];

            if (string.IsNullOrWhiteSpace(_serverName) ||
                string.IsNullOrWhiteSpace(_port) ||
                string.IsNullOrWhiteSpace(_database))
            {
                throw new Exception("La configuración de Sybase está incompleta.");
            }
        }

        private void SafeClose()
        {
            try
            {
                if (_connection != null)
                {
                    if (_connection.State != ConnectionState.Closed)
                    {
                        _connection.Close();
                    }
                    _connection.Dispose();
                    _connection = null;
                }
            }
            catch (Exception ex)
            {
                LogError("Error al cerrar la conexión Sybase", ex);
            }
        }

        private void LogError(string message, Exception ex)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sybase_errors.log");
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine + ex + Environment.NewLine;
                File.AppendAllText(path, text);
            }
            catch
            {
            }
        }
    }
}