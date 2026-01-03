using Minotti.utils;
using Minotti.Views.Basicos.Models;
using System;

namespace Minotti.Views.Pbl.Controls
{
    public class uo_sepad : uo_app, IDisposable
    {
        private bool _disposed;

        // type variables (PB)
        private string helpactivo;
        private string directoriodelhelp;
        private string ejecutabledelhelp;

        public uo_sepad() : base()
        {
            // PB: create
        }

        // event ue_cargar_datos_app
        public virtual void ue_cargar_datos_app()
        {
            // ==============================
            // PB: call super::ue_cargar_datos_app
            // ==============================
            base.ue_cargar_datos_app();

            // ==============================
            // PB: guo_app = this
            // ==============================
            if (Globales.guo_app == null)
            {
                Globales.guo_app = this;
            }

           

            string ls_Hoy = "Release 2025.12.27";
            
            /* Define algunos atributos de la aplicación */
            if (this.App != null)
            {
                this.App.DisplayName = "Minotti 2025";
            }
            this.ArcInicio = "minotti.ini";
            this.Version = ls_Hoy;
            this.Logo = FileUtils.GetAppFile("Pictures", "tapa1.bmp"); // "2_256.bmp"
                                     // this.Logo = "Sepad.bmp"
            this.Copyright =
                "El siguiente programa se encuentra protegido por las leyes de derecho de autor.";
            this.ventana_coneccion = "w_coneccion_sepad";
            this.motor_db = "SQL Anywhere";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;

            if (disposing)
            {
                // PB: liberar recursos administrados si existieran
            }

            // PB: liberar recursos no administrados si existieran
        }
    }

}
