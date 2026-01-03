using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public static class ArrayHelpers
    {
        public static void EnsureIndex<T>(ref T[] array, int index)
            where T : new()
        {
            if (array == null)
                array = new T[index + 1];

            if (index >= array.Length)
                Array.Resize(ref array, index + 1);

            if (array[index] == null)
                array[index] = new T();
        }
    }

}
