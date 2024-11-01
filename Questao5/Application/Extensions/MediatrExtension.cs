using MediatR;
using Questao5.Application.Commands;
namespace Questao5.Application.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatRApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BaseCommand).Assembly));
        }
    }
}
