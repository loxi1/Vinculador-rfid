using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace DS9908R_App
{
    public class DBConsultas
    {
        private string SECRET_KEY;
        private string SECRET_IV;
        private string METHOD;

        private byte[] key;
        private byte[] iv;

        public DBConsultas()
        {
            var config = LoadJsonConfig("tsconfig.json");

            SECRET_KEY = config.ContainsKey("SECRET_KEY") ? config["SECRET_KEY"] : "";
            SECRET_IV = config.ContainsKey("SECRET_IV") ? config["SECRET_IV"] : "";
            METHOD = config.ContainsKey("METHOD") ? config["METHOD"] : "AES-256-CBC";

            if (string.IsNullOrWhiteSpace(SECRET_KEY) || string.IsNullOrWhiteSpace(SECRET_IV))
            {
                throw new Exception("Faltan SECRET_KEY o SECRET_IV en tsconfig.json.");
            }

            key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
            iv = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)).Take(16).ToArray();
        }

        public static string GetConfigPath(string filePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("baseDirectory-->" + baseDirectory);

            string parent1 = Directory.GetParent(baseDirectory) != null
                ? Directory.GetParent(baseDirectory).FullName
                : baseDirectory;

            string parent2 = Directory.GetParent(parent1) != null
                ? Directory.GetParent(parent1).FullName
                : parent1;

            string iniDirectory = Path.Combine(parent2, "Ini");
            Console.WriteLine("iniDirectory-->" + iniDirectory);

            string configPath = Path.Combine(iniDirectory, filePath);
            Console.WriteLine("configPath-->" + configPath);

            return configPath;
        }

        public static Dictionary<string, string> LoadJsonConfig(string filePath)
        {
            string configPath = GetConfigPath(filePath);

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("No existe el archivo de configuración.", configPath);
            }

            string jsonContent = File.ReadAllText(configPath);
            var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);

            if (config == null)
            {
                throw new Exception("No se pudo deserializar el archivo de configuración.");
            }

            return config;
        }

        public string Encrypt(string stringToEncrypt)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                    byte[] cipherTextBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }

        public string Decrypt(string stringToDecrypt)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

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