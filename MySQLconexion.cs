using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace DS9908R_App
{
    class MySQLconexion
    {
        private MySqlConnection myConexion;
        private string m_ServerName = "";
        private string m_Port = "";
        private string m_Database = "";
        private string m_Usuario = "";
        private string m_Password = "";
        private string m_ConeccionLifeme = "";
    }
}
