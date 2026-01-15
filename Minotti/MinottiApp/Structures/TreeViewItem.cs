namespace Minotti.Structures
{
    public sealed class TreeViewItem
    {
        public int Level { get; set; }
        public object Data { get; set; } = "";
        public string? Label { get; set; } = "";
        public int PictureIndex { get; set; }
        public int SelectedPictureIndex { get; set; }
        public bool Children { get; set; }
    }
}
