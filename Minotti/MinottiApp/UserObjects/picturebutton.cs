using System.Windows.Forms;

namespace Minotti.UserObjects
{
    public class picturebutton : Button
    {
        public int X { get => Left; set => Left = value; }
        public int Y { get => Top; set => Top = value; }
    }
}
