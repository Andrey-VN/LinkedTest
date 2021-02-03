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
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(10);
            list.Add(22);
            list.Add(1212);
            list.Add(14);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            list.Remove(1);

            Console.WriteLine();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
