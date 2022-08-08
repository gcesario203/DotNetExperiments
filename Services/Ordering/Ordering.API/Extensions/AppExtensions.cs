using Microsoft.EntityFrameworkCore;

namespace Ordering.API.Extensions
{
    public static class AppExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost app, Action<TContext, IServiceProvider> seeder, int? retry = 0)
        where TContext : DbContext
        {
            int retryForAvaiability = retry.Value;

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");

                    if(retryForAvaiability < 50)
                    {
                        retryForAvaiability++;

                        Thread.Sleep(2000);

                        MigrateDatabase<TContext>(app, seeder, retryForAvaiability);
                    }
                }

                return app;
            }
        }

        public static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
        {
            context.Database.Migrate();

            seeder(context, services);
        }
    }
}