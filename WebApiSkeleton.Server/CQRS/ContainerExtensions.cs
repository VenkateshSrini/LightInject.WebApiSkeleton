using System.Linq;
using LightInject;

namespace WebApiSkeleton.Server.CQRS
{
    public static class ContainerExtensions
    {
        public static void RegisterQueryHandlers(this IServiceRegistry serviceRegistry)
        {
            var assembly = typeof (ContainerExtensions).Assembly;
           
            var queryHandlerTypes = assembly.GetTypes()
                .Where(
                    t =>
                        t.GetInterfaces()
                            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (IQueryHandler<,>)));
            foreach (var queryHandlerType in queryHandlerTypes)
            {
                var interfaceType =
                    queryHandlerType.GetInterfaces()
                        .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (IQueryHandler<,>));
                serviceRegistry.Register(interfaceType, queryHandlerType);
            }
        }

        public static void EnableCQRS(this IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IQueryExecutor>(factory => new QueryExecutor(factory));
        }

    }
}