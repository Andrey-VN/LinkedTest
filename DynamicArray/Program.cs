using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayList
{

    class DynamicArray<T> : IEnumerable<T>
    {
        T[] data;
        int Count { get; set; }

        public DynamicArray() : this(4)
        {

        }

        public DynamicArray(int index)
        {
            data = new T[index];
        }

        private void Resize()
        {
            int Size = Count == 0 ? 4 : 2 * data.Length;

            T[] arr = new T[Size];
            data.CopyTo(arr, 0);
            data = arr;
        }

        private bool IsFull()
        {
            return Count == data.Length;
        }

        public void Add(T item)
        {
            if (IsFull())
                Resize();
            data[Count++] = item;
        }

        public void Insert(T item, int index)
        {
            if (IsFull())
                Resize();
            Array.Copy(data, index, data, index + 1, Count - index);
            data[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            int shift = index + 1;
            if (shift < Count)
                Array.Copy(data, shift, data, index, Count - shift);           
            Count--;
            data[Count] = default;
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (item.Equals(data[i]))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(data[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(5);

            dynamicArray.Insert(10, 2);
            Console.WriteLine(dynamicArray.IndexOf(10));


            foreach(var i in dynamicArray)
                Console.WriteLine(i);
            Console.ReadLine();

        }
    }
}
