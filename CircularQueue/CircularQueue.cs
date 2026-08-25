/* Week 1 */
// Queue<int> queue = new Queue<int>(3);
// string? inputs;
// Console.WriteLine("Enter commands Log(val) or Read(), separated by ';' or ',' (Ctrl+C to exit):");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         string[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
//     else
//     {
//         string[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
// }


// static void QueueManager(Queue<int> queue, string input)
// {
//     if (input.Contains("Log("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
//         int value;
//         bool isNumeric = int.TryParse(item, out value);
//         if (!isNumeric)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid integer.");
//             return;
//         }
//         if (queue.Count < 3)
//         {
//             Console.WriteLine($"Logged {value}");
//             queue.Enqueue(value);
//         }
//         else
//         {
//             Console.WriteLine("Buffer Full");
//         }

//     }
//     else if (input.Contains("Read()"))
//     {
//         if (!(queue.Count() == 0))
//         {
//             Console.WriteLine($"Read {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Buffer is empty");
//         }
//     }
// }

/* Week 2 */
// Queue<int> queue = new Queue<int>(3);
// string? inputs;
// Console.WriteLine("Enter commands Log(val) or Read(), separated by ';' or ',' (Ctrl+C to exit):");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         string[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
//     else
//     {
//         string[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
// }


// static void QueueManager(Queue<int> queue, string input)
// {
//     if (input.Contains("Log("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
//         int value;
//         bool isNumeric = int.TryParse(item, out value);
//         if (!isNumeric)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid integer.");
//             return;
//         }
//         if (queue.Count < 3)
//         {
//             Console.WriteLine($"Logged {value}");
//             queue.Enqueue(value);
//         }
//         else
//         {
//             queue.Dequeue();
//             Console.WriteLine($"Overwritten oldest with {value}");
//             queue.Enqueue(value);
//         }

//     }
//     else if (input.Contains("Read()"))
//     {
//         if (!(queue.Count() == 0))
//         {
//             Console.WriteLine($"Read {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Buffer is empty");
//         }
//     }
// }

/* Week 3 */
// Queue<int> queue = new Queue<int>(3);
// string? inputs;
// Console.WriteLine("Enter commands Log(val) or Read(), separated by ';' or ',' (Ctrl+C to exit):");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         string[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
//     else
//     {
//         string[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
// }


// static void QueueManager(Queue<int> queue, string input)
// {
//     if (input.Contains("Log("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
//         int value;
//         bool isNumeric = int.TryParse(item, out value);
//         if (!isNumeric)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid integer.");
//             return;
//         }
//         if (queue.Count < 3)
//         {
//             Console.WriteLine($"Logged {value}");
//             queue.Enqueue(value);
//             if (queue.Count >= 2)
//             {
//                 if (queue.Count == 3)
//                 {
//                     Console.WriteLine("Critical: Buffer Full");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Warning: Buffer at 66%");
//                 }
//             }
//         }
//         else
//         {
//             queue.Dequeue();
//             Console.WriteLine($"Overwritten oldest with {value}");
//             queue.Enqueue(value);
//         }

//     }
//     else if (input.Contains("Read()"))
//     {
//         if (!(queue.Count() == 0))
//         {
//             Console.WriteLine($"Read {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Buffer is empty");
//         }
//     }
// }


/* Week 4 */
namespace CircularQueueExercise;

public class CircularQueue
{
    private bool _isOverwrittenEnabled = true;
    private int _capacity = 3;
    Queue<int> queue = new Queue<int>();
    public void SetOverwritePolicy(bool isOverwriteEnabled)
    {
        _isOverwrittenEnabled = isOverwriteEnabled;
    }
    public void SetCapacity(int n)
    {
        _capacity = n;
    }

    public (bool Success, int? OverwrittenValue) Log(int value)
    {
        if (queue.Count == _capacity && _isOverwrittenEnabled)
        {
            int overwrittenValue = queue.Dequeue();
            queue.Enqueue(value);

            return (true, overwrittenValue);
        }

        if (queue.Count == _capacity && !_isOverwrittenEnabled)
        {
            return (false, null);
        }

        queue.Enqueue(value);
        return (true, null);
    }
    public int Read()
    {
        return queue.Dequeue();
    }
}




// CircularQueue queue = new CircularQueue();
// string inputs;
// Console.WriteLine("Enter commands Log(val) or Read(), separated by ';' or ',' (Ctrl+C to exit):");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         string[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
//     else
//     {
//         string[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
// }

// static void QueueManager(CircularQueue queue, string input)
// {
//     if (input.Contains("Log("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
//         int value;
//         bool isNumeric = int.TryParse(item, out value);
//         if (!isNumeric)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid integer.");
//             return;
//         }
//         queue.Enqueue(value);
//     }
//     else if (input.Contains("Read()"))
//     {
//         if (!queue.CheckIfEmpty())
//         {
//             Console.WriteLine($"Read {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Buffer is empty");
//         }
//     }
// }

// class CircularQueue
// {
//     private readonly int[] _queue;
//     private int _head;
//     private int _tail;
//     private int _count;

//     public CircularQueue()
//     {
//         _queue = new int[3];
//         _head = 0;
//         _tail = 0;
//         _count = 0;
//     }

//     public bool CheckIfEmpty()
//     {
//         return _count == 0;
//     }

//     public bool CheckIfFull()
//     {
//         return _count == _queue.Length;
//     }

//     public void Enqueue(int value)
//     {
//         if (CheckIfFull())
//         {
//             Console.WriteLine("Buffer full");
//             return;
//         }

//         _queue[_tail] = value;
//         Console.WriteLine($"Logged {value}");

//         _tail = (_tail + 1) % _queue.Length;
//         _count++;
//     }

//     public int Dequeue()
//     {
//         if (CheckIfEmpty())
//             throw new InvalidOperationException("Buffer is empty.");

//         int value = _queue[_head];

//         _head = (_head + 1) % _queue.Length;
//         _count--;

//         return value;
//     }
// }
