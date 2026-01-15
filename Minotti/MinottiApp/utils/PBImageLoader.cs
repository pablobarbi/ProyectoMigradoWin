using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;

namespace Minotti.utils
{
    /// <summary>
    /// Loader simple para imágenes estilo PowerBuilder (bmp/png) usadas por menús y ListView/TreeView.
    /// No inventa rutas: busca en ./Pictures (copiado al output) y cachea por nombre.
    /// </summary>
    public static class PBImageLoader
    {
        private static readonly ConcurrentDictionary<string, Image?> _cache = new(StringComparer.OrdinalIgnoreCase);

        public static Image? Load(string? pictureName)
        {
            if (string.IsNullOrWhiteSpace(pictureName)) return null;

            return _cache.GetOrAdd(pictureName.Trim(), key =>
            {
                try
                {
                    // Si viene con ruta absoluta/relativa, intentar directo.
                    if (File.Exists(key))
                        return Image.FromFile(key);

                    // Buscar en carpeta Pictures al lado del exe.
                    var baseDir = AppContext.BaseDirectory;
                    var picsDir = Path.Combine(baseDir, "Pictures");

                    // Permitir que el nombre venga sin extensión ("confirmar" -> confirmar.bmp)
                    string[] candidates = key.Contains('.')
                        ? new[] { Path.Combine(picsDir, key) }
                        : new[]
                        {
                            Path.Combine(picsDir, key + ".bmp"),
                            Path.Combine(picsDir, key + ".png"),
                            Path.Combine(picsDir, key + ".jpg"),
                            Path.Combine(picsDir, key + ".jpeg"),
                        };

                    foreach (var path in candidates)
                    {
                        if (File.Exists(path))
                            return Image.FromFile(path);
                    }

                    return null;
                }
                catch
                {
                    return null;
                }
            });
        }
    }
}
