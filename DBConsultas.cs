using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace DS9908R_App
{
    class DBConsultas
    {
        // Variables de configuración
        private string SECRET_KEY;
        private string SECRET_IV;
        private string METHOD;

        // Variables para clave y vector de inicialización
        private byte[] key;
        private byte[] iv;

        // Constructor que carga los valores desde un archivo JSON
        public DBConsultas()
        {
            string filePath = "tsconfig.json";

            // Obtener el directorio base de ejecución
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"baseDirectory-->{baseDirectory}");

            // Subir dos niveles para llegar a "bin"
            string binDirectory = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;
            Console.WriteLine($"binDirectory-->{binDirectory}");

            // Construir la ruta del archivo tsconfig.json
            string iniDirectory = Path.Combine(binDirectory, "Ini");
            Console.WriteLine($"iniDirectory-->{iniDirectory}");

            string configPath = Path.Combine(iniDirectory, filePath);
            Console.WriteLine($"configPath-->{configPath}");

            // Leer y procesar el archivo JSON
            if (File.Exists(configPath))
            {
                string jsonContent = File.ReadAllText(configPath);
                var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);

                // Extraer los valores de configuración
                SECRET_KEY = config["SECRET_KEY"];
                SECRET_IV = config["SECRET_IV"];
                METHOD = config["METHOD"];

                // Convertir SECRET_KEY y SECRET_IV a hash de 256 bits y 128 bits respectivamente
                key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
                iv = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)).Take(16).ToArray();
            }
            else
            {
                throw new FileNotFoundException(
                    $"baseDirectory->{baseDirectory} binDirectory->{binDirectory} iniDirectory->{iniDirectory} configPath->{configPath}"
                );
            }
        }

        // Función para cifrar un texto
        public string Encrypt(string stringToEncrypt)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                    byte[] cipherTextBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }

        // Función para descifrar un texto
        public string Decrypt(string stringToDecrypt)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] cipherTextBytes = Convert.FromBase64String(stringToDecrypt);
                    byte[] plainTextBytes = decryptor.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
                    return Encoding.UTF8.GetString(plainTextBytes);
                }
            }
        }
    }
}
