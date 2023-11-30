using System.Text;
using Api.Common;
using Api.Common.Interfaces;
using Api.Common.Mappings;
using Api.Context;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services, builder.Configuration);

var application = builder.Build();

ConfigureApp(application);

await application.RunAsync();


void RegisterServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql("Name=Database"));
    services.AddAutoMapper(expression =>
        expression.AddProfile(new AssemblyMappingProfile(typeof(Program).Assembly)));
    services.AddTransient<ITokenService, TokenService>();
    services
        .AddCors(options => options.AddPolicy(Constants.CorsName, policy =>
        {
            policy
                .WithMethods(
                    HttpMethods.Get,
                    HttpMethods.Post,
                    HttpMethods.Put,
                    HttpMethods.Delete)
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed(_ => true)
                .WithExposedHeaders("content-disposition");
        }))
        .ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; })
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
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
