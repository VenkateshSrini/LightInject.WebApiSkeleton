using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using LightInject;
using WebApiSkeleton.Server.CQRS;
using WebApiSkeleton.Server.Customers;

namespace WebApiSkeleton.Server
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            EnsureDatabaseIsInitialized();

            serviceRegistry.EnableCQRS();
            //serviceRegistry.RegisterQueryHandlers();

            serviceRegistry.Register<ICustomerService, CustomerService>();

            serviceRegistry.Register<IQueryHandler<CustomersQuery, Customer[]>, CustomersQueryHandler>();

            // We register the connection that it is disposed when the scope ends.
            // The scope here is per web request.
            serviceRegistry.Register(factory => CreateConnection(), new PerScopeLifetime());
        }

        private static IDbConnection CreateConnection()
        {
            var connection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            return connection;
        }

        private void EnsureDatabaseIsInitialized()
        {
            using (var connection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                var result = connection.ExecuteScalar<int?>(SQL.DatabaseInitializedQuery);
                if (result == null)
                {
                    connection.Execute(SQL.CreateDatabase);
                }
            }
        }

    }
}