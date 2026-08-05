// int n = int.Parse(Console.ReadLine());
// object box = n;
// Console.WriteLine(box.ToString());
// for (int i = 1; i <= n; i++)
// {
//     if (i % 3 == 0 && i % 5 == 0)
//     {
//         // Console.Write("foobar, ");
//     }
//     else if (i % 3 == 0)
//     {
//         // Console.Write("foo, ");
//     }
//     else if (i % 5 == 0)
//     {
//         // Console.Write("bar, ");
//     }
//     else
//     {
//         // Console.Write(i + ", ");

//     }
// }
namespace ConsoleApp1;

public abstract class Asset
{
    public string Name = string.Empty; // Fixed CS8618 by providing a default value

    static Asset()
    {
        // Static constructor
        Console.WriteLine("im from asset");
    }

    public abstract decimal NetValue { get; }
}

public class Stock : Asset
{

    static Stock()
    {
        Console.WriteLine("Im from Stock");
        // Console.WriteLine(Stock.SharesOwned);
        // Console.WriteLine(Stock.CurrentPrice);
    }

    public long SharesOwned {get; set;}
    public decimal CurrentPrice {get; set;}
    
    public Stock(string name,long sharesOwned, decimal currentPrice)
    {
        Name = name;
        SharesOwned = sharesOwned;
        CurrentPrice = currentPrice;
    }
 
    public override decimal NetValue => CurrentPrice * SharesOwned;
}

class Program
{
    static void Main(string[] args)
    {
        Asset asset = new Stock("AAPL", 20000L, 150.00m);
        Stock asset2 = new Stock("GOOGL", 10000L, 200.00m);
        Console.WriteLine($"Asset Name: {asset2.Name}, Net Value: {asset2.NetValue}");
        Console.WriteLine($"Asset Name: {asset.Name}, Net Value: {asset.NetValue}");
    }
}