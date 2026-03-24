using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svg;
using System.Windows.Forms;
using System.Drawing;

namespace DS9908R_App
{
    class UtilidadesSVG
    {
        public string ObtenerRutaSVG(string fileName)
        {
            try
            {
                // Obtener la ruta base de la aplicación
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Subir dos niveles para llegar a la carpeta "bin"
                //string binDirectory = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName;

                // Construir la ruta de la carpeta "Ini"
                string iniDirectory = Path.Combine(baseDirectory, "Ini");

                // Construir la ruta completa del archivo SVG
                string svgFilePath = Path.Combine(iniDirectory, fileName);

                System.Diagnostics.Debug.WriteLine("fileName->"+ fileName + " base->" + baseDirectory + " inDirectory->"+ iniDirectory+ " svgFilePath->"+ svgFilePath);

                // Verificar si el archivo existe
                if (File.Exists(svgFilePath))
                {
                    return svgFilePath;
                }
                else
                {
                    Console.WriteLine($"⚠️ Archivo SVG no encontrado: {svgFilePath}");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error obteniendo la ruta SVG: {ex.Message}");
                return string.Empty;
            }
        }

        public void CargarIconoSVG(PictureBox pictureBox, string svgFileName)
        {
            if (pictureBox == null)
            {
                MessageBox.Show("❌ El PictureBox es NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener la ruta del archivo SVG
            string svgPath = ObtenerRutaSVG(svgFileName);

            // Validar que el archivo existe
            if (string.IsNullOrEmpty(svgPath))
            {
                MessageBox.Show($"⚠️ Archivo SVG no encontrado: {svgPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cargar el documento SVG
                SvgDocument svgDocument = SvgDocument.Open(svgPath);
                if (svgDocument == null)
                {
                    MessageBox.Show("⚠️ No se pudo cargar el SVG.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Renderizar el SVG como Bitmap
                Bitmap bitmap = svgDocument.Draw();

                if (bitmap == null)
                {
                    MessageBox.Show("⚠️ Error al convertir SVG a Bitmap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar la imagen al PictureBox
                pictureBox.Image = bitmap;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Error al cargar el archivo SVG.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
