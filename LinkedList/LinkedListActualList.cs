using System;
namespace LinkedListExercise;

public class LinkedListActualList
{
    private Node _head = null;
    private Node _tail = null;

    public void Append(int value)
    {
        Node newNode = new Node()
        {
            Value = value
        };
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
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
        Console.Write($"Sequence {currentNode.Value}");
        currentNode = currentNode.Next;

        while (currentNode != null)
        {
            Console.Write($" -> {currentNode.Value}");
            currentNode = currentNode.Next;
        }
        Console.WriteLine();
    }
}
