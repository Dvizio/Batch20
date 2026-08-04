using System;
namespace LinkedListExercise
{
    internal class LinkedListActualList
    {
        private Node _head = null;
        private Node _tail = null;

        public void Append(int value)
        {
            Node newNode = new Node(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail._next = newNode;
                _tail = newNode;
            }
        }

        public void Print()
        {
            if (_head == null)
            {
                Console.WriteLine("The linked list is empty.");
                return;
            }

            Node currentNode = _head;
            Console.Write($"Sequence {currentNode._value}");
            currentNode = currentNode._next;

            while (currentNode != null)
            {
                Console.Write($" -> {currentNode._value}");
                currentNode = currentNode._next;
            }
            Console.WriteLine();
        }
    }
}