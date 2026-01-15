 
namespace Minotti.Structures
{
    public class NodeTag
    {
        public int Handle { get; set; }
        public object? Data { get; set; }

        // payload funcional
        public string? Modulo { get; set; }
        public string? Operacion { get; set; }

        public NodeTag(int handle, object? data)
        {
            Handle = handle;
            Data = data;
        }

        public NodeTag() { }
    }

}
