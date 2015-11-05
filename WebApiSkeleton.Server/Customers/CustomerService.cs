using System.Threading.Tasks;
using WebApiSkeleton.Server.CQRS;

namespace WebApiSkeleton.Server.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IQueryExecutor queryExecutor;

        public CustomerService(IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
        }

        public Task<Customer[]> GetCustomersByCountry(string country)
        {
            return queryExecutor.ExecuteAsync(new CustomersQuery {Country = country});
        }
    }
}