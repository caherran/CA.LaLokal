using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CA.Util.DependencyInjection;
using System.Reflection;

namespace CA.LaLokal.Back.Application
{
    public class DependencyRegister : IDependencyRegister
    {
        public void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
