using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;

namespace DS9908R_App
{
    public class MySQLconexion
    {
        private MySqlConnection _connection;
        private string _serverName = "";
        private string _port = "";
        private string _database = "";
        private string _user = "";
        private string _password = "";
        private string _connectionLifetime = "300";

        public string LastError { get; private set; }

        public MySqlConnection Connect()
        {
            try
            {
                ResetConnection();
                LoadConfig();

                string connectionString =
                    string.Format(
                        "Database={0};Port={1};Data Source={2};Uid={3};Pwd={4};Connection Lifetime={5};",
                        _database,
                        _port,
                        _serverName,
                        _user,
                        _password,
                        string.IsNullOrWhiteSpace(_connectionLifetime) ? "300" : _connectionLifetime);

                if (_connection == null)
                {
                    _connection = new MySqlConnection(connectionString);
                }

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                return _connection;
            }
            catch (Exception ex)
            {
                LastError = "Error al conectar MySQL: " + ex.Message;
                LogError("Error al conectar MySQL", ex);
                throw;
            }
        }

        public void Disconnect()
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
                LastError = ex.Message;
                LogError("Error al cerrar MySQL", ex);
            }
        }

        public bool IsConnected()
        {
            return _connection != null && _connection.State == ConnectionState.Open;
        }

        public string GetError()
        {
            return LastError ?? string.Empty;
        }

        public void ResetConnection()
        {
            if (_connection != null &&
                (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken))
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = Connect())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
                }

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        private void LoadConfig()
        {
            Dictionary<string, string> config = DBConsultas.LoadJsonConfig("tsconfig.json");

            _serverName = config.ContainsKey("DB_SERVER_MY") ? config["DB_SERVER_MY"] : "";
            _port = config.ContainsKey("DB_PORT_MY") ? config["DB_PORT_MY"] : "";
            _database = config.ContainsKey("DB_NAME_MY") ? config["DB_NAME_MY"] : "";
            _user = config.ContainsKey("DB_USER_MY") ? config["DB_USER_MY"] : "";
            _password = config.ContainsKey("DB_PASSWORD_MY") ? config["DB_PASSWORD_MY"] : "";
            _connectionLifetime = config.ContainsKey("Connection Lifetime") ? config["Connection Lifetime"] : "300";

            if (string.IsNullOrWhiteSpace(_serverName) ||
                string.IsNullOrWhiteSpace(_port) ||
                string.IsNullOrWhiteSpace(_database) ||
                string.IsNullOrWhiteSpace(_user))
            {
                throw new Exception("La configuración de MySQL está incompleta.");
            }
        }

        private void LogError(string message, Exception ex)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mysql_errors.log");
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine + ex + Environment.NewLine;
                File.AppendAllText(path, text);
                Debug.WriteLine(text);
            }
            catch
            {
            }
        }
    }
}