using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProductService : IService
{

}
public static class ServiceLocator 
{
    private static readonly IDictionary<Type, IService> _registeredServices = new Dictionary<Type, IService>();

    public static T GetService<T>() 
        where T : IService
    {
        Type key = typeof(T);
        if (!_registeredServices.ContainsKey(key))
        {
            Debug.LogWarning ("Service not found");
        }
        return (T)_registeredServices[typeof(T)];
    }

    public static void AddService<T>(T service)
        where T : IService
    {
        if (service.Equals (default(T))) 
        {
            return;
        }

        Type key = typeof(T);
        if (_registeredServices.ContainsKey(key))
        {
            return;
        }

        _registeredServices.Add(key, service);
    }

    public static Int32 Count
    {
        get { return _registeredServices.Count; }
    }

    
    //public bool LoadAllServices(Dictionary<Type, IService> services)
    //{
        
    //    //ICustomerService customerService = new CustomerService();

    //    IProductService timerService = new TimerService();

    //    //ServiceLocator.RegisterService(timerService);


    //}
}

