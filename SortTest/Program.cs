using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class Program
    {

        private static void Swap(ref int left, ref int right)
        {
            if (left != right)
            {
                int temp = right;
                right = left;
                left = temp;
            }
        }
        public static void BubbleSort(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                        Swap(ref array[i], ref array[j]);
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            int inn = 0;
            int outt;
            for(int i = 1; i < array.Length; i++)
            {
                if(array[i] < array[i-1])
                {
                    outt = i;  ///с какого индекс переместить значение
                    for(int j = 0; j < array.Length; j++)
                    {
                        if (array[j] > array[i])
                        {
                            inn = j;  //на какой индекс переместить значение
                            break;
                        }
                    }
                    int temp = array[inn];
                    array[inn] = array[outt];
                    //сдвигаем элементы от индекса, в который вставили значение
                    for(int current = outt; current > inn; current--)
                    {
                        array[current] = array[current - 1];
                    }
                    array[inn +1] = temp;
                }
            }
        }

        public static void SelectionSort(int [] array)
        {
            int rang = 0;
            int currentMin = 0;
            int indexCurrentMin = 0;
            for (int i = rang; i < array.Length; i++)
            {
                currentMin = array[i];
                indexCurrentMin = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if(currentMin > array[j])
                    {
                        currentMin = array[j];
                        indexCurrentMin = j;
                    }
                }
                Swap(ref array[indexCurrentMin], ref array[i]);
            }
        }
        public static void MegreSort(int[] array)
        {
            if (array.Length <= 1)
                return;
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(array, 0, left, 0, leftSize);
            Array.Copy(array, leftSize, right, 0, rightSize);

            MegreSort(left);
            MegreSort(right);

            Marge(array, left, right);
        }
        private static void Marge(int[] items, int[] left, int[] right)
        {
            int indexRight = 0;
            int indexLeft = 0;
            int indexTarget = 0;
            int remaining = left.Length + right.Length; // общая длинна правой и левой части сортируемого массива
            while(remaining > 0)
            {
                if (indexLeft == left.Length)
                {
                    items[indexTarget] = right[indexRight++];
                }
                else if (indexRight == right.Length)
                {
                    items[indexTarget] = left[indexLeft++];
                }
                else if (left[indexLeft] < right[indexRight])
                {
                    items[indexTarget] = left[indexLeft++];
                }
                else if (left[indexLeft] >= right[indexRight])
                {
                    items[indexTarget] = right[indexRight++];
                }


                indexTarget++;
                remaining--;
            }
        }
        static void Main(string[] args)
        {
            int[] mass = { 2, 3, 4, 12, 4, 6, 4, 7, 1, 5};
            MegreSort(mass);

            for(int i = 0; i < mass.Length; i++)
                Console.WriteLine(mass[i]);
            Console.ReadLine();
        }
    }
}
