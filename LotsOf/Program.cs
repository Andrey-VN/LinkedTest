using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOf
{
    public class Lots<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();

        public Lots()
        {

        }
        public Lots(IEnumerable<T> item)
        {
            AddRange(item);
        }

        public void Add(T item)
        {
            if(!this.Contains(item))
                list.Add(item);
            else
                Console.WriteLine($"Параметр \"{item}\" есть в множестве, добавить его невозможно и добавлен не будет");
            
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }


        public void AddRange(IEnumerable<T> item)
        {
            foreach(var i in item)
            {
                this.Add(i);
            }
        }

        public int Count { get { return list.Count; } }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }


        public Lots<T> Union(Lots<T> item)
        {
            Lots<T> ts = new Lots<T>(list);
            foreach(var i in item.list)
            {
                if (!Contains(i))
                    ts.Add(i);
            }
            return ts;

        }

        public Lots<T> Intersection(Lots<T> item)
        {
            Lots<T> ts = new Lots<T>();
            foreach(var i in item.list)
            {
                if (Contains(i))
                    ts.Add(i);
            }
            return ts;
        }

        public Lots<T> Difference(Lots<T> item)
        {
            Lots<T> ts = new Lots<T>(list);
            
            foreach (var i in item.list)
            {
                ts.Remove(i);
            }
            return ts;
        }
        public Lots<T> SymmetricDifferenc(Lots<T> item)
        {
            Lots<T> ts1 = new Lots<T>(list);
            Lots<T> ts2 = new Lots<T>(item);
            Lots<T> ts3 = ts1.Union(ts2);
            Lots<T> ts4 = ts1.Intersection(ts2);
            Lots<T> ts5 = ts3.Difference(ts4);
            return ts5;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Lots<int> lot1 = new Lots<int> { 1, 2, 3, 4, 5, 99 };
            Lots<int> lot2 = new Lots<int> { 1, 2, 3, 6, 5, 4, 7, 8 };
            Lots<int> lot3;

            lot3 = lot1.SymmetricDifferenc(lot2);

            foreach(var i in lot3)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

    }
}
