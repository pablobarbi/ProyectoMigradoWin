using Minotti.Data;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    partial class w_multilinea_bak
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "w_multilinea_bak";
            this.Text = "w_multilinea_bak";
            this.Width = 2684;
            this.Height = 1365;
        }
    }
}
