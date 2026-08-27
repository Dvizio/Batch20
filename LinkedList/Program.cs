using LinkedListExercise;

public class Program
{
    public static void Main()
    {
        var list = new LinkedListActualList();

        list.SetSorting(compared);


        list.AddFilter(val => val % 2 == 0);


        list.Append(3);
        list.Append(10);
        list.Append(8);
        list.Append(2);

        Console.WriteLine($"Sequence: {list.Print()}");
        Console.WriteLine($"Sequence: {list.PrintReverse()}");
    }
    public static int compared(int a, int b)
    {
        return b.CompareTo(a);
    }
}