using EFDatabaseLayer;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer;
using System.Diagnostics;

public class OrderService : IOrderService
{
    private readonly EfcoreOptimizationLabContext _context;

    public OrderService(EfcoreOptimizationLabContext context)
    {
        _context = context;
    }

    public List<Order> GetAllOrders()
    {
        var sw = Stopwatch.StartNew();
        var result =  _context.Orders.ToList(); // 2396 ms
        sw.Stop();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Time taken for getting data with tracking: {0}",sw.ElapsedMilliseconds);
        sw = Stopwatch.StartNew();
        result = _context.Orders.AsNoTracking().ToList(); // 937 ms 
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Time taken for getting data without tracking: {0}",sw.ElapsedMilliseconds);
        sw.Stop();
        return result;
    }
}
