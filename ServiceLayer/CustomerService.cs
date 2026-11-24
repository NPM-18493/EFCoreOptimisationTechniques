using EFDatabaseLayer;
namespace ServiceLayer;

public class CustomerService : ICustomerService
{
    private readonly EfcoreOptimizationLabContext _context;

    public CustomerService(EfcoreOptimizationLabContext context)
    {
        _context = context;
    }

    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }
}
