using System;

namespace Umit_Aydin_GameOfWar
{
    public static class Extensions
    {
        public static T[] Remove<T>(this T[] array, int index)
        {
            var arr = new T[array.Length];
            var arr2 = new T[] { };

            Array.ForEach(array, val =>
            {
                try
                {
                    if (array[index] != null && !array[index]!.Equals(val))
                    {
                        arr[index] = array[index];
                        array.CopyTo(arr,index);
                    }
                    
                } catch {}
            });
            
            return arr;
        }
    }
}