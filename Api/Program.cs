using Api.Common;
using Api.Common.Mappings;
using Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var application = builder.Build();

ConfigureApp(application);

await application.RunAsync();


void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql("Name=Database"));
    services.AddAutoMapper(configuration =>
        configuration.AddProfile(new AssemblyMappingProfile(typeof(Program).Assembly)));
}

void ConfigureApp(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseRouting();
    app.UseCors(Constants.CorsName);
    //app.UseAuthentication();
    //app.UseAuthorization();
    app.MapControllers();
}
