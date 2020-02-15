using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScopedCSS
{
    public static class ConfigurationExtensions
    {
        public static void AddScopedCSS(this IServiceCollection service)
        {
            service.AddScoped<CSSProvider>();
        }
    }
}
