using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FileUtilities;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorFileUtilities(this IServiceCollection services)
    {
        return services.AddTransient<FileService>();
    }
}
