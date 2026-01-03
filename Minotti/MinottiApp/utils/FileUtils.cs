using System;
using System.IO;

namespace Minotti.utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Devuelve la ruta completa de un archivo ubicado en la carpeta de la aplicación.
        /// PB-like: reemplaza uso de "..\Pictures\archivo.bmp"
        /// </summary>
        public static string GetAppFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                fileName
            );
        }

        /// <summary>
        /// Variante para subcarpetas (ej: Pictures, Reports, etc)
        /// </summary>
        public static string GetAppFile(string folder, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                folder,
                fileName
            );
        }


        public static string ResolveImage(string fileName)
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Pictures",
                fileName
            );
        }

    }
}
