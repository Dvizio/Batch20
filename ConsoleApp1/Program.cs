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

// public class Asset
// {
//     public string Name = string.Empty; // Fixed CS8618 by providing a default value

//     static Asset()
//     {
//         // Static constructor
//         Console.WriteLine("im from asset");
//     }

//     public virtual decimal NetValue { get; }
// }

// public class Stock : Asset
// {

//     static Stock()
//     {
//         Console.WriteLine("Im from Stock");
//         // Console.WriteLine(Stock.SharesOwned);
//         // Console.WriteLine(Stock.CurrentPrice);
//     }

//     public long SharesOwned {get; set;}
//     public decimal CurrentPrice {get; set;}

//     public Stock(string name,long sharesOwned, decimal currentPrice)
//     {
//         Name = name;
//         SharesOwned = sharesOwned;
//         CurrentPrice = currentPrice;
//     }

//     public override decimal NetValue => CurrentPrice * SharesOwned;
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Asset asset = new Stock("AAPL", 2, 2);
//         // Stock asset2 = new Stock("GOOGL", 10000L, 200.00m);
//         // Console.WriteLine($"Asset Name: {asset2.Name}, Net Value: {asset2.NetValue}");
//         Console.WriteLine($"Asset Name: {asset.Name}, Net Value: {asset.NetValue}");
//     }
// }

interface IAsset
{
    string Name { get; set; }
    decimal NetValue { get; }
    void DisplayInfo(string james);
}

class Stock : IAsset
{
    public string Name { get; set; }
    public long SharesOwned { get; set; }
    public decimal CurrentPrice { get; set; }
    private StockType _stockType;

    struct Point
    {
        int x = 1;      // Field initializer
        int y;
        public Point() => y = 1; // Explicit parameterless constructor
        private int _z = 1; // Field initializer
        public int GetZ()
        {
            return _z;
        } // Method to access _z
    }

    public enum StockType
    {
        Common,
        Preferred,
        Trash
    }

    public int GetStockTypeValue()
    {
        return (int)_stockType;
    }

    public Stock(string name, long sharesOwned, decimal currentPrice)
    {
        Name = name;
        SharesOwned = sharesOwned;
        CurrentPrice = currentPrice;
        _stockType = DetermineStockType();
    }

    private StockType DetermineStockType()
    {
        if (CurrentPrice < 10)
        {
            return StockType.Trash;
        }
        else if (CurrentPrice < 100)
        {
            return StockType.Common;
        }
        else
        {
            return StockType.Preferred;
        }
    }

    public decimal NetValue => CurrentPrice * SharesOwned;

    public void DisplayInfo(string james)
    {
        Console.WriteLine($"Stock Name: {Name}, Shares Owned: {SharesOwned}, Current Price: {CurrentPrice}, Net Value: {NetValue}, Stock Type: {_stockType}. Hi my name is {james}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stock asset = new Stock("AAPL", 200, 1.00m);
        asset.DisplayInfo("John");
        // asset.GetStockTypeValue();
        
        
        Console.WriteLine(asset.GetStockTypeValue() == 2 ? "LOL DUMBAHH" : "Smart choice boss");
    }
}