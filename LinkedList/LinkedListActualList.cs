using System;
namespace LinkedListExercise;

public class LinkedListActualList
{
    private Node? _head = null;
    private Node? _tail = null;
    private Func<int, int, int>? _comparer = null;
    private readonly List<Func<int, bool>> _filters = new();

    public void Clear()
    {
        _head = null;
        _tail = null;
        _comparer = null;
        _filters.Clear();
    }
    public void SetSorting(Func<int, int, int> comparer)
    {
        _comparer = comparer;
    }

    public void AddFilter(Func<int, bool> filterRule)
    {
        _filters.Add(filterRule);
    }

    public void Append(int value)
    {
        Node newNode = new Node { Value = value };
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (_comparer == null)
        {
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
            return;
        }

        if (_comparer(value, _head.Value) < 0)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        Node cursor = _head;
        while (cursor.Next != null && _comparer(value, cursor.Next.Value) >= 0)
        {
            cursor = cursor.Next;
        }

        newNode.Next = cursor.Next;
        newNode.Previous = cursor;

        if (cursor.Next != null)
        {
            cursor.Next.Previous = newNode;
        }
        else
        {
            _tail = newNode;
        }

        cursor.Next = newNode;
    }


    public string? Print()
    {
        if (_head == null)
        {
            return null;
        }

        Node? currentNode = _head;
        List<int> outputValues = new();

        while (currentNode != null)
        {
            if (ShouldInclude(currentNode.Value))
            {
                outputValues.Add(currentNode.Value);
            }
            currentNode = currentNode.Next;
        }

        if (outputValues.Count == 0)
        {
            return null;
        }
        return string.Join(" -> ", outputValues);
    }
    public string? PrintReverse()
    {
        if (_tail == null)
        {
            return null;
        }

        Node? currentNode = _tail;
        List<int> outputValues = new();

        while (currentNode != null)
        {
            if (ShouldInclude(currentNode.Value))
            {
                outputValues.Add(currentNode.Value);
            }
            currentNode = currentNode.Previous;
        }
        if (outputValues.Count == 0)
        {
            return null;
        }
        return string.Join(" -> ", outputValues);

    }
    private bool ShouldInclude(int value)
    {
        foreach (var filter in _filters)
        {
            if (!filter(value))
            {
                return false; // Skip if any filter returns false
            }
        }
        return true;
    }
}
