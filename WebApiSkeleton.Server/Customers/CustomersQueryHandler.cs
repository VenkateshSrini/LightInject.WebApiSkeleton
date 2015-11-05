using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WebApiSkeleton.Server.CQRS;

namespace WebApiSkeleton.Server.Customers
{   
    public class CustomersQueryHandler : IQueryHandler<CustomersQuery, Customer[]>
    {
        private readonly IDbConnection dbConnection;

        public CustomersQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<Customer[]> HandleAsync(CustomersQuery query)
        {
            var result = await dbConnection.QueryAsync<Customer>(SQL.CustomersByCountry, query);
            return result.ToArray();
        }
    }
}
