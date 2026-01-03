using System;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migración de PowerBuilder: w_dwsaveas.srw
    /// Posiciones y tamaños 1:1 según XAML PBWPF.
    /// </summary>
    public partial class w_dwsaveas : Form
    {
        // Variables PB preservadas
        public int il_availablerow { get; set; }
        public int il_sortingrow { get; set; }
        public uo_sortattrib inv_sortattrib { get; set; } = new uo_sortattrib();
        public cat_return at_return { get; set; } = new cat_return();
        public uo_ds idw { get; set; } = new uo_ds();
        public bool ib_visibleonly { get; set; }

        public w_dwsaveas()
        {
            InitializeComponent();
        }
    }
}
