using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Minotti.utils
{
    public static class PBPictureBox
    {

        /// <summary>
        /// PowerBuilder: picture.picturename
        /// </summary>
        public static void SetPictureName(this PictureBox pb, string pictureName)
        {
            if (pb == null)
                return;

            if (string.IsNullOrWhiteSpace(pictureName))
            {
                pb.Image = null;
                return;
            }

            try
            {
                // Si es ruta absoluta o relativa
                if (File.Exists(pictureName))
                {
                    pb.Image = Image.FromFile(pictureName);
                    return;
                }

                // Intento desde el directorio de la aplicación
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(appPath, pictureName);

                if (File.Exists(fullPath))
                {
                    pb.Image = Image.FromFile(fullPath);
                    return;
                }

                // Si no existe, limpio la imagen (PB no rompe)
                pb.Image = null;
            }
            catch
            {
                // PB-style: fallar silenciosamente
                pb.Image = null;
            }
        }
    }
}
 
