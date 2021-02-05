using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackList
{

    public class StackL<T>
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

        Node head { get; set; }
        int Count { get; set; }

        public void Push(T item)
        {
            Node node = new Node(item);
            if(Count == 0)
            {
                head = node;
            }
            else
            {
                node.Next = head;
                head = node;
            }
            Count++;

        }
        public T Pop()
        {
            if (Count != 0)
            {
                Node item = head;
                head = head.Next;
                Count--;
                return item.Value;
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

            Stack<int> vs = new Stack<int>();
            vs.Push(1);
            vs.Push(2);
            vs.Push(3);
            vs.Push(4);
            vs.Push(5);
            Console.WriteLine(vs.Pop());
            Console.WriteLine(vs.Pop());
            Console.WriteLine(vs.Pop());
            Console.WriteLine(vs.Pop());
            Console.WriteLine(vs.Peek());
            Console.Read();
        }
    }
}
