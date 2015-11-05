using System.Threading.Tasks;

namespace WebApiSkeleton.Server.Customers
{
    public interface ICustomerService
    {
        Task<Customer[]> GetCustomersByCountry(string country);
    }
}