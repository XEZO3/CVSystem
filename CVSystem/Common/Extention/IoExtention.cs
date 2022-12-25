using CV.DAL.Repository;
using CV.Service.Service;
using Domain.IRepository;
using Domain.IService;

namespace CVSystem.Common.Extention
{
    public static class IoExtention
    {
        public static IServiceCollection RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IExperianceRepository, ExperianceRepository>();
            builder.Services.AddScoped<IExperianceService, ExperianceService>();
            builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
            builder.Services.AddScoped<IPersonalService, PersonalService>();
            builder.Services.AddScoped<ICVRepository, CVRepository>();
            builder.Services.AddScoped<ICVService, CVService>();
            return builder.Services;
        }
    }
}
