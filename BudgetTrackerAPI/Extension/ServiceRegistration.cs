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
            services.AddScoped<TransactionRepository>();

            // Business 
            services.AddScoped<UserBusiness>();
            services.AddScoped<CategoryBusiness>();
            services.AddScoped<TransactionBusiness>();

            // Service 
            services.AddScoped<UserService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<TransactionService>();

            return services;
        }
    }
}
