using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedTest
{

    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode(T val)
        {
            Value = val;
        }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previos { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;
        public int Count { get; set; }
        public void Add(T val)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(val);
            if(head == null)
            {
                head = node;
                
            }
            else
            {
                tail.Next = node;
               
            }
            tail = node;
            Count++;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;
            while(current!=null)
            {
                if(current.Value.Equals(item))
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous;
                        }

                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> node = head;
            while(node!=null)
            {
                yield return node.Value;
                node = node.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> node = head;
            while(node!=null)
            {
                if(node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;             
            }
            return false;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int index)
        {
            LinkedListNode<T> node = head;
            while(node!=null)
            {
                array[index++] = node.Value;
                node = node.Next;
            }
        }

        public void AddFirst(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);
            LinkedListNode<T> temp = head;

            head = node;
            head.Next = temp;
            if(Count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previos = head;
            }
            Count++;

        }
        public void AddLast(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);
            LinkedListNode<T> temp = tail;

            tail = node;
            temp.Next = tail;

            if(Count == 0)
            {
                head = tail;
            }
            else
            {
                tail.Previos = temp;
            }
            Count++;
        }

        public void RemoveLast()
        {
            
            if(Count > 1)
            {
                tail.Previos.Next = null;
                tail = tail.Previos;

                Count--;
            }
            else if(Count == 1)
            {
                head = null;
                tail = null;
            }
        }
        public void RemoveFirst()
        {
            if (Count > 1)
            {
                head.Next.Previos = null;
                head = head.Next;
                Count--;
            }
            else
            {
                head = null;
                tail = null;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(10);
            //list.Add(22);
            //list.Add(1212);
            //list.Add(14);

            //foreach (var i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //list.Remove(1);

            //Console.WriteLine();

            //foreach (var i in list)
            //{
            //    Console.WriteLine(i);
            //}

            //int[] arr = new int[] { 1, 2, 3, 4, 5, 7, 19, 34, 11, 222, 2, 2, 2, };
            //Console.WriteLine();
            //list.CopyTo(arr, 2);
            //for(int i = 0; i < arr.Length;i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //Console.WriteLine(list.Contains(14));


            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(5);
            list.AddFirst(6);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            list.RemoveLast();
            list.RemoveLast();
            list.RemoveLast();
            list.RemoveLast();
            list.RemoveLast();
            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
