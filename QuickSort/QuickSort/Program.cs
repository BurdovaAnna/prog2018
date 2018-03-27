using System;

namespace QuickSort
{
    public class Program
    {
       public static void QuickSort(int[] array, int start, int end)
        {
            if (end == start || array.Length == 0) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i < end; i++)
                if (array[i] <= pivot)
                {
                    var swap1 = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = swap1;
                    storeIndex++;
                }
            var swap2 = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = swap2;
            if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
            if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
