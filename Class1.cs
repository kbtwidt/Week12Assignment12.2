using System;
using System.Collections.Generic;
using System.Text;

namespace Week12Assignment12._2
{
    internal class Node
    {
        public int Data { get; set; }
        public Node next;

        public Node(int value)
        {
            Data = value;
            next = null;
        }
    }

    class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;
        public int Size { get { return size; } }
        public LinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void AddFirst(int item)
        {
            Node newNode = new Node(item);
            if (IsEmpty())
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = head;
                this.head = newNode;
            }
            size++;
        }

        public void AddLast(int item)
        {
            Node newNode = new Node(item);
            if (IsEmpty())
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                tail.next = newNode;
                this.tail = newNode;
            }
            size++;
        }

        public void Display()
        {
            Node tempNode = head;
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }
            else
            {
                while (tempNode != null)
                {
                    Console.Write(tempNode.Data + " ");
                    tempNode = tempNode.next;
                }
            }
        }

        public int RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Linked list is empty");
            int val = head.Data;
            head = head.next;
            size--;

            if (IsEmpty())
                tail = null;
            return val;
        }

        public int RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Linked list is empty");
            int val = tail.Data;
            Node tempNode = head;
            int i = 1;
            while (i < size - 1)
            {
                tempNode = tempNode.next;
                i++;
            }
            tail = tempNode;
            tail.next = null;
            size--;

            if (IsEmpty())
                head = null;
            return val;
        }
        public void AddPostion(int val, int position)
        {
            if (position <= 0 || position > size + 1)
                throw new InvalidOperationException("Position is invalid.");
            if (position == 1)
            {
                AddFirst(val);
                return;
            }
            if (position == size + 1)
            {
                AddLast(val);
                return;
            }
            Node newNode = new Node(val);
            Node tempNode = head;
            int i = 1;
            while (i < position - 1)
            {
                tempNode = tempNode.next;
                i++;
            }
            newNode.next = tempNode.next;
            tempNode.next = newNode;
            size++;
        }

        public int RemovePostion(int position)
        {
            if (position <= 0 || position > size)
                throw new InvalidOperationException("Position is invalid");
            if (position == 1)
            {
                return RemoveFirst();
            }
            if (position == size)
            {
                return RemoveLast();
            }
            Node tempNode = head;
            int i = 1;
            while (i < position - 1)
            {
                tempNode = tempNode.next;
                i++;
            }
            int val = tempNode.next.Data;
            tempNode.next = tempNode.next.next;
            size--;
            return val;
        }

        public bool Search(int value)
        {
            Node tempNode = head;

            while (tempNode != null)
            {
                if (tempNode.Data == value)
                {
                    return true;
                }

                tempNode = tempNode.next;
            }

            return false;
        }

        public void RemoveValue(int val)
        {
            // Remove matching nodes from the beginning of the list
            while (head != null && head.Data == val)
            {
                head = head.next;
                size--;
            }

            // If the list is now empty
            if (head == null)
            {
                tail = null;
                return;
            }

            // Traverse the rest of the list
            Node tempNode = head;

            while (tempNode.next != null)
            {
                if (tempNode.next.Data == val)
                {
                    tempNode.next = tempNode.next.next;
                    size--;
                }
                else
                {
                    tempNode = tempNode.next;
                }
            }

            // Update tail
            tail = tempNode;
        }
    }
}
