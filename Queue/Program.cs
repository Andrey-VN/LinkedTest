using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{

    public class QueueList<T>
    {
        class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
            public Node(T val)
            {
                Value = val;
            }
        }

        Node head;
        Node tail;
        int Count { get; set; }

        public void Enqueue(T item)
        {
            Node node = new Node(item);
            if (Count == 0)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        public T Dequeue()
        {
            if(Count!=0)
            {
                Node node = head;

                head = head.Next;
                Count--;
                return node.Value;
               
            }
            return default;
        }
        public T Peek()
        {
            return head.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QueueList<int> queueList = new QueueList<int>();

            queueList.Enqueue(1);
            queueList.Enqueue(2);
            queueList.Enqueue(3);
            queueList.Enqueue(4);
            queueList.Enqueue(5);

            Console.WriteLine(queueList.Dequeue());
            Console.WriteLine(queueList.Dequeue());
            Console.WriteLine(queueList.Dequeue());
            Console.WriteLine(queueList.Dequeue());
            Console.WriteLine(queueList.Dequeue());



            Console.ReadLine();


        }
    }
}
