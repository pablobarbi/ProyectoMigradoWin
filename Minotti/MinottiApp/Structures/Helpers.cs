namespace Minotti.Structures
{

    public struct uost_tab_info
    {
        public string titulo;
        public string dw;
        public string bitmap;
        public string parametros;

    }
    // type uost_sort from structure
    public struct uost_sort
    {
        public string columna;
        public string orden;
    }

    // type uost_seguridad from structure
    public struct uost_seguridad
    {
        public string usuario;
        public string fecha;
    }
    public struct environment
    {
        public int ScreenWidth;
        public int ScreenHeight;
        // agregá lo que uses después
    }

    public enum RowFocusIndicator
    {
        None = 0,
        Hand = 1,
        Arrow = 2
    }

    public enum PBRowMoveMode
    {
        Before = 1,   // PB: move before row
        After = 2,    // PB: move after row
        Replace = 3,   // PB: replace row (si aparece en el legado)
        Delete = 4     // PB: borrar filas origen luego del move
    }

    public enum Pointer
    {
        Arrow = 0,
        HourGlass = 1,
        Busy = 2
    }

}
