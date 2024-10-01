using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            //.net servislerini al ve onları kendin
            //build et web api-autofacde vs oluşturduğumuz
            //enjectionları oluşturmamızı sağlıyor
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}