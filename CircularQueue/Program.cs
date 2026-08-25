using CircularQueueExercise;

var ngawi = new CircularQueue();
ngawi.SetCapacity(4);
ngawi.SetOverwritePolicy(true);
var test = ngawi.Log(2);
if (test.Success)
{
    Console.WriteLine($"Logged Success");
}
test = ngawi.Log(3);
if (test.Success)
{
    Console.WriteLine($"Logged Success");
}
test = ngawi.Log(4);
if (test.Success)
{
    Console.WriteLine($"Logged Success");
}
test = ngawi.Log(5);
if (test.Success)
{
    Console.WriteLine($"Logged Success");
}
test = ngawi.Log(6);
if (test.Success)
{
    Console.WriteLine($"Overwritten {test.OverwrittenValue}");
}
ngawi.SetOverwritePolicy(false);
test = ngawi.Log(2);
if (!test.Success)
{
    Console.WriteLine("Rejected");
}
Console.WriteLine($"read : {ngawi.Read()}");
