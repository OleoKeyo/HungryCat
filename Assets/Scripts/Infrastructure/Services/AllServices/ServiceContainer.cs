using System;
using System.Collections.Generic;

namespace Infrastructure.Services.AllServices
{
  public class ServiceContainer
  {
    private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    public void RegisterSingle<TService>(TService implementation) 
      where TService : IService
    {
      Type serviceType = typeof(TService);
      _services[serviceType] = implementation;
    }
    
    public TService Resolve<TService>() where TService : class, IService
    {
      Type serviceType = typeof(TService);
      if(_services.TryGetValue(serviceType, out IService service))
      {
        return service as TService;
      }

      throw new KeyNotFoundException($"ServiceType {serviceType} not found");
    }
  }
}