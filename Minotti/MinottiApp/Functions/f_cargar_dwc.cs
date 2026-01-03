using Minotti.Data;
using Minotti.utils;


namespace Minotti.Functions
{
    /// <summary>
    /// Migración de PB: f_cargar_dwc.srf
    /// Firma original: global function integer f_cargar_dwc (ref datawindowchild dwc, string s_arg[])
    /// Mantengo nombre del archivo, clase y método.
    /// </summary>
    public static class f_cargar_dwc
    {
        public static int fcargar_dwc(datawindowchild dwc, string[] s_arg)
        {
            // Equivalente PB: dwc.SetTransObject(SQLCA)
            dwc.SetTransObject(SQLCA.Connection);

            // Equivalente PB: Retorno = dwc.InsertRow(0)
            int Retorno = dwc.InsertRow(0);

            // Return(Retorno)
            return Retorno;
        }
    }
}
