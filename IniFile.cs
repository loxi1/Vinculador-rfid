using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DS9908R_App
{
    class IniFile
    {
        internal string m_directory = "";
        internal string m_fileIni = "";
        internal IConfiguration _config;
        internal string m_error;
        internal bool lb_exist = false;

        public bool LoadConfiguracion()
        {
            string ls_directory = GetDirectory();
            string ls_fileIni = GetFileIni();
            string ls_pathFileIni = Path.Combine(m_directory, m_fileIni);
            lb_exist = File.Exists(ls_pathFileIni);
            m_error = "";
            if (lb_exist)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(ls_directory) // Establece la carpeta base para la búsqueda del archivo .ini
                .AddIniFile(ls_fileIni); // Agrega el configuracion.ini como fuente de configuración

                _config = builder.Build();
                return true;
            }
            else
            {
                m_error = "No se ecnuentra archivo de configuracion en :" + ls_pathFileIni;
                return false;
            }

        }

        public string GetValue(string section, string key)
        {
            // Aquí implementa la lógica para leer secciones y claves del archivo .ini
            // Puedes usar System.IO.File y métodos de manejo de cadenas para esto
            if (lb_exist)
            {
                if (_config[section + ":" + key] != null)
                {
                    return _config[section + ":" + key];
                }
            }
            return "";
        }

        public void SetValue(string section, string key, string value)
        {
            if (lb_exist)
            {
                var config = new Dictionary<string, Dictionary<string, string>>();

                foreach (var sec in _config.GetChildren())
                {
                    var secConfig = new Dictionary<string, string>();
                    foreach (var item in sec.GetChildren())
                    {
                        secConfig[item.Key] = item.Value;
                    }
                    config[sec.Key] = secConfig;
                }

                if (!config.ContainsKey(section))
                {
                    config[section] = new Dictionary<string, string>();
                }

                config[section][key] = value;

                Write(config);
            }
        }

        private void Write(Dictionary<string, Dictionary<string, string>> sections)
        {
            if (lb_exist)
            {
                string ls_fileini = Path.Combine(m_directory, m_fileIni);
                using (StreamWriter writer = new StreamWriter(ls_fileini))
                {
                    foreach (var section in sections)
                    {
                        writer.WriteLine($"[{section.Key}]");

                        foreach (var kvp in section.Value)
                        {
                            writer.WriteLine($"{kvp.Key}={kvp.Value}");
                        }

                        writer.WriteLine(); // Línea en blanco entre secciones
                    }
                }

            }
        }

        public void SetDirectory(string sdirectory)
        {
            m_directory = sdirectory;
        }

        public string GetDirectory()
        {
            if (m_directory.Length == 0)
            {
                string directorioActual = Directory.GetCurrentDirectory();

                // Obtener información del directorio actual
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioActual);

                // Obtener el directorio padre
                DirectoryInfo directorioPadre = directorioInfo.Parent;
                string ls_path = directorioPadre?.FullName;

                m_directory = Path.Combine(ls_path, "Ini");
            }

            return m_directory;
        }

        public void SetFileIni(string sfileIni)
        {
            m_fileIni = sfileIni;
        }

        public string GetFileIni()
        {
            if (m_fileIni.Length == 0)
            {
                m_fileIni = "configuracion.ini";
            }

            return m_fileIni;
        }

        public string GetError()
        {
            return m_error;
        }
    }
}
