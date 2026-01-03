using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Pbl.Controls;
using System;
using System.Windows.Forms;

namespace Minotti
{
    // PB: global type sepad from application
    public class uo_sepad : uo_app, IDisposable
    {
        private bool _disposed;

        // type variables (PB)
        private string helpactivo;
        private string directoriodelhelp;
        private string ejecutabledelhelp;

        public uo_sepad() : base()
        {
            PBLog.Log($"[uo_sepad.CTOR] Nueva instancia creada | Hash={GetHashCode()}");
        }

        // ==========================================
        // PB: event ue_cargar_datos_app
        // ==========================================
        public override void ue_cargar_datos_app()
        {
            PBLog.Log($"[uo_sepad.ue_cargar_datos_app] ENTER | Hash={GetHashCode()}");

            // PB: call super
            base.ue_cargar_datos_app();
            PBLog.Log($"[uo_sepad.ue_cargar_datos_app] base OK");

            // PB: guo_app = this (SOLO UNA VEZ)
            if (Globales.guo_app == null)
            {
                Globales.guo_app = this;
                PBLog.Log($"[uo_sepad] Globales.guo_app SET | Hash={GetHashCode()}");
            }
            else
            {
                PBLog.Log(
                    $"[uo_sepad] ⚠ Globales.guo_app YA EXISTE | Actual={Globales.guo_app.GetHashCode()} | Nuevo={GetHashCode()}"
                );
            }

            string ls_Hoy = "Release 2025.12.27";

            // Definición de atributos de aplicación
            if (this.App != null)
            {
                this.App.DisplayName = "Minotti 2025";
                PBLog.Log("[uo_sepad] App.DisplayName set");
            }
            else
            {
                PBLog.Log("[uo_sepad] ❌ App es NULL");
            }

            this.ArcInicio = "minotti.ini";
            this.Version = ls_Hoy;
            this.Logo = "tapa1.bmp";
            this.Copyright =
                "El siguiente programa se encuentra protegido por las leyes de derecho de autor.";
            this.ventana_coneccion = "w_coneccion_sepad";
            this.motor_db = "SQL Anywhere";

            PBLog.Log("[uo_sepad.ue_cargar_datos_app] EXIT OK");
        }

        // ==========================================
        // IDisposable
        // ==========================================
        public void Dispose()
        {
            PBLog.Log($"[uo_sepad.Dispose] Dispose() | Hash={GetHashCode()}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            PBLog.Log($"[uo_sepad.Dispose] disposing={disposing} | Hash={GetHashCode()}");

            _disposed = true;

            if (disposing)
            {
                // liberar recursos administrados
            }
        }
    }

}