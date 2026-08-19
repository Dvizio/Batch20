using System;
namespace LinkedListExercise;

public class LinkedListActualList
{
    private Node? _head = null;
    private Node? _tail = null;

    public void Clear()
    {
        _head = null;
        _tail = null;
    }

    public void Append(int value)
    {
        // Console.WriteLine($"trying to append {value}");
        Node newNode = new Node()
        {
            Value = value
        };
        if (_head == null)
        {
            _head = newNode;
            _head.Previous = null;
            _tail = newNode;
        }
        else
        {
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
            _tail.Next = null;
        }
    }

    public void Insert(int value)
    {
        Node newNode = new Node
        {
            Value = value
        };

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        Node cursor = _head;

        if (value < cursor.Value)
        {
            Console.WriteLine("HERE");
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        while (cursor.Next != null && value >= cursor.Next.Value)
        {
            cursor = cursor.Next;
        }

        // Console.WriteLine($"input after {cursor.Value}");
        newNode.Next = cursor.Next;
        newNode.Previous = cursor;

        if (cursor.Next != null)
        {
            cursor.Next.Previous = newNode;
        }
        else
        {
            _tail = newNode;
            Console.WriteLine("here");
        }

        cursor.Next = newNode;
    }


    public void Print()
    {
        if (_head == null)
        {
            Console.WriteLine("The linked list is empty.");
            return;
        }

        Node? currentNode = _head;
        Console.Write($"Sequence: {currentNode.Value}");
        currentNode = currentNode.Next;

        while (currentNode != null)
        {
            Console.Write($" -> {currentNode.Value}");
            currentNode = currentNode.Next;
        }
        Console.WriteLine();
    }

    public void PrintReverse()
    {
        if (_tail == null)
        {
            Console.WriteLine("The linked list is empty.");
            return;
        }

        Node? currentNode = _tail;
        Console.Write($"Reversed: {currentNode.Value}");
        currentNode = currentNode.Previous;

        while (currentNode != null)
        {
            Console.Write($" -> {currentNode.Value}");
            currentNode = currentNode.Previous;
        }
        Console.WriteLine();

    }
}
