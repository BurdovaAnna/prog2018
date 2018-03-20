using System;

namespace Lab2BinarySearch
{
    class Program

    {

        public static int BinarySearch(int[] array, int value)

        {
            //код поиска значения value в массиве array
            if (array.Length == 0) return -1;
            var left = 0;
            var right = array.Length - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (value <= array[middle])
                    right = middle;
                else left = middle + 1;
            }
            if (array[right] == value)
                return right;
            return -1;
        }



        static void Main(string[] args)
        {
            TestFiveElementsArray();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestRepeatingElement();
            TestEmptyArray();
            TestBigArray();

            Console.ReadKey();
        }


        private static void TestFiveElementsArray()
        {
            //Тестирование поиска одного элемента в массиве из 5 элементов
            int[] fiveElementsArray = new[] { 1, 2, 3, 5, 7 };
            if (BinarySearch(fiveElementsArray, 3) != 2)
                Console.WriteLine("! Поиск не нашёл число 3 среди чисел { 1, 2, 3, 5, 7 }");
            else
                Console.WriteLine("Поиск одного элемента в массиве из 5 элементов работает корректно");
        }

        private static void TestNegativeNumbers()

        {

            //Тестирование поиска в отрицательных числах

            int[] negativeNumbers = new[] { -5, -4, -3, -2 };

            if (BinarySearch(negativeNumbers, -3) != 2)

                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");

            else

                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");

        }

        private static void TestNonExistentElement()

        {

            //Тестирование поиска отсутствующего элемента

            int[] negativeNumbers = new[] { -5, -4, -3, -2 };

            if (BinarySearch(negativeNumbers, -1) >= 0)

                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");

            else

                Console.WriteLine("Поиск отсутствующего элемента работает корректно");

        }
        private static void TestRepeatingElement()
        {
            //Тестирование поиска элемента, повторяющегося несколько раз
            int[] repetingNumbers = new[] { 1, 2, 3, 4, 4, 4, 5 };
            var foundIndex = BinarySearch(repetingNumbers, 4);
            if (repetingNumbers[foundIndex] != 4)
                Console.WriteLine("! Поиск не нашёл число 4 среди чисел { 1, 2, 3, 4, 4, 4, 5}");
            else
                Console.WriteLine("Поиск элемента, повторяющегося несколько раз работает корректно");
        }

        private static void TestEmptyArray()
        {
            //Тестирование поиска в пустом массиве (содержащем 0 элементов)
            int[] emptyArray = new int[0];
            if (BinarySearch(emptyArray, 2) >= 0)
                Console.WriteLine("! Поиск нашёл число 2 в пустом массиве");
            else
                Console.WriteLine("Поиск в пустом массиве работает корректно");
        }

        private static void TestBigArray()
        {
            //Тестирование поиска в  массиве из 100001 элементов
            int[] bigArray = new int[100001];
            bigArray[0] = 0;
            for (int i = 1; i < bigArray.Length - 1; i++)
                bigArray[i] = bigArray[i - 1] + i;
            var searchValue = bigArray[1000];
            if (BinarySearch(bigArray, searchValue) != 1000)
                Console.WriteLine($"! Поиск не нашёл число {searchValue} в массиве из 100001 элементов");
            else
                Console.WriteLine("Поиск в массиве из 100001 элементов работает корректно");
        }
    }

}