using System.Windows.Forms;

namespace Minotti.utils
{
    /// <summary>
    /// Equivalente PowerBuilder:
    ///   Left!   -> Left
    ///   Right!  -> Right
    ///   Center! -> Center
    /// </summary>
    public enum ListViewColumnAlignment
    {
        Left = 0,
        Right = 1,
        Center = 2
    }



    public static class PBListViewExtensions
    {
        // =====================================================
        // PB: lv_1.DeleteColumns()
        // =====================================================
        public static void DeleteColumns(this ListView lv)
        {
            lv.Columns.Clear();
        }

        // =====================================================
        // PB: lv_1.DeleteItems()
        // =====================================================
        public static void DeleteItems(this ListView lv)
        {
            lv.Items.Clear();
        }

        // =====================================================
        // PB: lv_1.AddColumn(titulo, align, width)
        // =====================================================
        public static void AddColumn(
            this ListView lv,
            string text,
            ListViewColumnAlignment alignment,
            int width)
        {
            var col = new ColumnHeader
            {
                Text = text,
                Width = width,
                TextAlign = alignment switch
                {
                    ListViewColumnAlignment.Left => HorizontalAlignment.Left,
                    ListViewColumnAlignment.Right => HorizontalAlignment.Right,
                    ListViewColumnAlignment.Center => HorizontalAlignment.Center,
                    _ => HorizontalAlignment.Left
                }
            };

            lv.Columns.Add(col);
        }

        // =====================================================
        // PB: lv_1.AddItem(lvi)
        // Devuelve índice 1-based como PB
        // =====================================================
        public static int AddItem(this ListView lv, PBListViewItemExtensions pbItem)
        {
            var item = new ListViewItem
            {
                Text = pbItem.Label,
                ImageIndex = pbItem.PictureIndex,
                StateImageIndex = pbItem.StatePictureIndex,
                Tag = pbItem.Data
            };

            lv.Items.Add(item);

            // PB es 1-based
            return lv.Items.Count;
        }

        // =====================================================
        // PB: lv_1.GetItem(index, lvi)
        // =====================================================
        public static void GetItem(this ListView lv, int index, out PBListViewItemExtensions pbItem)
        {
            // PB index es 1-based
            var item = lv.Items[index - 1];

            pbItem = new PBListViewItemExtensions
            {
                Label = item.Text,
                Data = item.Tag,
                PictureIndex = item.ImageIndex,
                StatePictureIndex = item.StateImageIndex
            };
        }

    

        // =====================================================
        // PB: lv_1.SelectedIndex
        // Retorna índice 1-based, 0 si no hay selección
        // =====================================================
        public static int SelectedIndex(this ListView lv)
        {
            if (lv.SelectedIndices.Count == 0)
                return 0;

            // PB es 1-based
            return lv.SelectedIndices[0] + 1;
        }

        // =====================================================
        // PB: lv_1.AddSmallPicture("file.bmp")
        // Devuelve el índice de la imagen agregada
        // =====================================================
        public static void AddSmallPicture(this ListView lv, string pictureName)
        {
            if (lv == null)
                return;
                //throw new ArgumentNullException(nameof(lv));

            if (string.IsNullOrWhiteSpace(pictureName))
                return;

            // En PB el ImageList siempre existe → en WinForms no
            if (lv.SmallImageList == null)
            {
                lv.SmallImageList = new ImageList
                {
                    ImageSize = new Size(16, 16),
                    ColorDepth = ColorDepth.Depth32Bit
                };
            }

            // Evitar duplicados
            if (lv.SmallImageList.Images.ContainsKey(pictureName))
                return;

            // 🔹 Resolución PB-style del archivo
            string basePath = Application.StartupPath;

            string fullPath = Path.Combine(basePath, pictureName);
            if (!File.Exists(fullPath))
            {
                // intento en carpeta Images (muy común en PB)
                fullPath = Path.Combine(basePath, "Pictures", pictureName);
                if (!File.Exists(fullPath))
                    return; // PB: si no existe, no rompe
            }

            using var imgTemp = Image.FromFile(fullPath);
            var img = new Bitmap(imgTemp);

            lv.SmallImageList.Images.Add(pictureName, img);
        }


    }

}

    public sealed class PBListViewItemExtensions
    {
        public string Label { get; set; } = "";
        public object? Data { get; set; }
        public int PictureIndex { get; set; }
        public int StatePictureIndex { get; set; }
    }

 
