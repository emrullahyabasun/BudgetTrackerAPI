using BudgetTracker.Business;
using BudgetTracker.DataAccessLayer;
using BudgetTracker.DataAccessLayer.Abstract;
using BudgetTracker.DataAccessLayer.Interface;
using BudgetTracker.Services;

namespace BudgetTrackerAPI.Extension
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Generic Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Özel Repositoriler
            services.AddScoped<UserRepository>();
            services.AddScoped<CategoryRepository>();

            // Business 
            services.AddScoped<UserBusiness>();
            services.AddScoped<CategoryBusiness>();

            // Service 
            services.AddScoped<UserService>();
            services.AddScoped<CategoryService>();
            return services;
        }
    }
}
