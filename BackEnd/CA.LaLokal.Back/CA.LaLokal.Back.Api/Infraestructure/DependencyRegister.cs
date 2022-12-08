using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CA.Util.DependencyInjection;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Api.Infraestructure
{
    public class DependencyRegister : IDependencyRegister
    {
        public void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
