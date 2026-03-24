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
                if (string.IsNullOrWhiteSpace(fileName))
                    return string.Empty;

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string parent1 = Directory.GetParent(baseDirectory) != null
                    ? Directory.GetParent(baseDirectory).FullName
                    : baseDirectory;

                string iniDirectory = Path.Combine(parent1, "Ini");
                string svgFilePath = Path.Combine(iniDirectory, fileName);

                System.Diagnostics.Debug.WriteLine(
                    "fileName->" + fileName +
                    " base->" + baseDirectory +
                    " iniDirectory->" + iniDirectory +
                    " svgFilePath->" + svgFilePath);

                if (File.Exists(svgFilePath))
                {
                    return svgFilePath;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void CargarIconoSVG(PictureBox pictureBox, string svgFileName)
        {
            if (pictureBox == null || string.IsNullOrWhiteSpace(svgFileName))
                return;

            string svgPath = ObtenerRutaSVG(svgFileName);

            if (string.IsNullOrWhiteSpace(svgPath) || !File.Exists(svgPath))
                return;

            try
            {
                SvgDocument svgDocument = SvgDocument.Open(svgPath);
                if (svgDocument == null)
                    return;

                Bitmap bitmap = svgDocument.Draw();
                if (bitmap == null)
                    return;

                pictureBox.Image = bitmap;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
            }
        }
    }
}
