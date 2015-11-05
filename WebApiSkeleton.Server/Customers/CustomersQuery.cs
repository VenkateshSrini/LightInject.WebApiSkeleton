using WebApiSkeleton.Server.CQRS;

namespace WebApiSkeleton.Server.Customers
{
    public class CustomersQuery : IQuery<Customer[]>
    {
         public string Country { get; set; }
    }
}