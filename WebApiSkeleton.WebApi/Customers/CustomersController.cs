using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiSkeleton.Server.Customers;
using Swashbuckle.Swagger.Annotations;
namespace WebApiSkeleton.WebApi.Customers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// Gets a list of customer resided in the given <paramref name="country"/>.
        /// </summary>
        /// <param name="country">The country for which to get the customers.</param>
        /// <returns>a list of customer resided in the given <paramref name="country"/>.</returns>
        [SwaggerResponse(HttpStatusCode.OK, "This is a description", typeof(Customer[]))]
        public async Task<IHttpActionResult> Get([FromUri]string country)
        {
            var result = await customerService.GetCustomersByCountry(country);
            return Ok(result);
        }
    }
}
