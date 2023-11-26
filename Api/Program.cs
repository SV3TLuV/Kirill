using Api.Common;
using Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var application = builder.Build();
ConfigureApp(application);

await using var scope = application.Services.CreateAsyncScope();
await using var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
await context.Database.EnsureCreatedAsync();

await application.RunAsync();


void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql("Name=Database"));
}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseRouting();
    app.UseCors(Constants.CorsName);
    //app.UseAuthentication();
    //app.UseAuthorization();
    app.MapControllers();
}