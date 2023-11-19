namespace Basket.API.Extensions
{
    public static class Extensions
    {

        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            return services;
        }
    }
}
