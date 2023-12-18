using Abstractions;
using DataAccess.ConnectionProviders;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection)
    {
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IOperationRepository, OperationRepository>();
        collection.AddScoped<IConnectionProvider, ConnectionProvider>();

        return collection;
    }
}