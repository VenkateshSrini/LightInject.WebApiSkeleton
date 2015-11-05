using System.Threading.Tasks;
using LightInject.xUnit2;
using Should;
using WebApiSkeleton.Server.CQRS;
using WebApiSkeleton.Server.Customers;
using Xunit;

namespace WebApiSkeleton.Server.Tests
{
    public class CustomersQueryTests
    {
        [Theory, InjectData, Scoped]
        public async Task ShouldReturnCustomerListForValidCountry(IQueryHandler<CustomersQuery, Customer[]> queryHandler)
        {
            var query = new CustomersQuery { Country = "Germany" };
            var result = await queryHandler.HandleAsync(query);
            result.ShouldNotBeEmpty();
        }

        [Theory, InjectData, Scoped]
        public async Task ShouldReturnEmptyListForUnknownCountry(IQueryHandler<CustomersQuery, Customer[]> queryHandler)
        {
            var query = new CustomersQuery { Country = "Fantasyland" };
            var result = await queryHandler.HandleAsync(query);
            result.ShouldBeEmpty();
        }       
    }
}
