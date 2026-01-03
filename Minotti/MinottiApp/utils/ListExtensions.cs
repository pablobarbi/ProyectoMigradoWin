using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public static class ListExtensions
    {
        /// <summary>
        /// PB-like: asegura que la lista tenga un índice disponible.
        /// Si la lista es muy corta, agrega elementos por default.
        /// </summary>
        public static void EnsureIndex<T>(this List<T> list, int index)
            where T : new()
        {
            if (list == null) return;

            // PB arrays comienzan en 1, pero en C# comenzamos en 0:
            int requiredCount = index + 1;

            while (list.Count < requiredCount)
                list.Add(new T());
        } 
    }

}
