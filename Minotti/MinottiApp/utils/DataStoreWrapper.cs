using Minotti.Views.Basicos.Controls;

namespace Minotti.utils
{
    public class DataStoreWrapper
    {
        private readonly uo_dw _dw;

        public DataStoreWrapper(string dataObject)
        {
            _dw = new uo_dw();
            _dw.uof_setdataobject(dataObject);
        }

        public void SetTransObject(object sqlca)
            => _dw.SetTransObject(sqlca);

        public long Retrieve(params object[] args)
            => _dw.Retrieve(args);

        public int RowCount => _dw.RowCount();

        public string GetItemString(int row, string column)
            => _dw.GetItemString(row, column);

        public void Destroy()
            => _dw.Destroy();
    }

}
