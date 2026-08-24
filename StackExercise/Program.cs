using StackExercise;
var ngawi = new StackEx();
ngawi.AddValidationRule(r => !string.IsNullOrWhiteSpace(r));
ngawi.AddValidationRule(r => r.Length <= 10);
Console.WriteLine(ngawi.Type("james"));
Console.WriteLine(ngawi.Type("hello"));
Console.WriteLine(ngawi.Type(" "));
ngawi.AddValidationRule(r => !r.Contains("jkw"));
Console.WriteLine(ngawi.Type("jkwdarisolo"));
Console.WriteLine(ngawi.Type("wa aja"));
Console.WriteLine(ngawi.Type("waa aja"));
Console.WriteLine(ngawi.Undo());
Console.WriteLine(ngawi.Undo());
Console.WriteLine(ngawi.Undo());
Console.WriteLine(ngawi.Undo());
Console.WriteLine(ngawi.Redo());
Console.WriteLine(ngawi.Redo());
Console.WriteLine(ngawi.Redo());

