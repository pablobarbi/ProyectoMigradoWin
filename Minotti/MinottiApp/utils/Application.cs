namespace Minotti.utils
{
    public class application
    {
        public string DisplayName { get; set; } = string.Empty;
        // PB: App.ToolBarText  (mostrar texto en toolbar)
        public bool ToolBarText { get; set; } = true;

        // PB: GetApplication()
        public static application GetApplication()
        {
            // Si ya tenés una instancia singleton interna, devolvela acá.
            // Si no, devolvemos una instancia nueva como stub.
            return new application();
        }
    }
}
