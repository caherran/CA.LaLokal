using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CA.Repository.Abstractions;
using CA.Util.DependencyInjection;
using System.Linq;

namespace CA.LaLokal.Back.Infraestructure
{
    public class DependencyRegister : IDependencyRegister
    {
        public void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            var assemblyRepositories = (typeof(DependencyRegister).Assembly).DefinedTypes.Where(t => t.Name.EndsWith("Repository") && !t.IsInterface);
            foreach (var repository in assemblyRepositories)
            {
                var interfaces = repository.GetInterfaces().Where(x => !x.Name.Equals(typeof(IRepository<>).Name));

                if (interfaces.Any())
                    services.AddScoped(interfaces.FirstOrDefault(), repository);
            }
        }
    }
}
