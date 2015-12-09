using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700_ICAs8JingLi
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            Node list = null;
            for (int i = 0; i < 10; i++)
            {
                JessieLinkedList.Append(ref list, generator.Next(0, 10));
            }
            Console.WriteLine("linked list before sorting\n");
            RecursivePrintList(list);
            Console.WriteLine("\n\n linked list after sorting");
            list = insertNode(list);
            RecursivePrintList(list);
            Console.ReadKey();
        }

        // insertion sort
        public static Node insertNode(Node node)
        {
            if (node == null)
                return null;

            // Make the first node the start of the sorted list.
            Node sortedList = node;
            node = node.Next;
            sortedList.Next = null;

            while (node != null)
            {
                // Advance the nodes.
                Node current = node;
                node = node.Next;

                // Find where current belongs.
                if (current.Data < sortedList.Data)
                {
                    // Current is new sorted head.
                    current.Next = sortedList;
                    sortedList = current;
                }
                else
                {
                    // Search list for correct position of current.
                    Node search = sortedList;
                    while (search.Next != null && current.Data > search.Next.Data)
                        search = search.Next;

                    // current goes after search.
                    current.Next = search.Next;
                    search.Next = current;
                }
            }
            node = sortedList;
            return node;
        }
        static public void RecursivePrintList(Node head)
        {
            if (head == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(head.Data + " ");

            //Head of the remainder of the list is just the next one after this one.
            RecursivePrintList(head.Next);

        }
        public static class JessieLinkedList
        {
            public static void Append(ref Node head, int data)
            {

                if (head != null)
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = new Node();
                    current.Next.Data = data;
                }
                else
                {
                    head = new Node();
                    head.Data = data;
                }
            }


            public static void PrintRecursive(Node head)
            {
                if (head == null)
                {
                    Console.WriteLine();
                    return;
                }

                Console.Write("{0} ", head.Data);
                PrintRecursive(head.Next);
            }

            public static void Reverse(ref Node head)
            {
                if (head == null) return;

                Node prev = null, current = head, next = null;

                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                current.Next = prev;
                head = current;
            }


        }

        public class Node
        {
            public int Data = 0;
            public Node Next = null;
        }
    }
}
