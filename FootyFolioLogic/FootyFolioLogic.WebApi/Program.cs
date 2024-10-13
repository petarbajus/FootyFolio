using Autofac;
using Autofac.Extensions.DependencyInjection;
using FootyFolio.Repository;
using FootyFolio.Repository.Common;
using FootyFolio.Service.Common;
using FootyFolioLogic.Service;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()   // This allows all origins, including ngrok URLs
                  .AllowAnyMethod()   // Allows any HTTP method (GET, POST, etc.)
                  .AllowAnyHeader();  // Allows any header
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Configure Autofac-specific services
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register your Autofac services, modules, etc.
    containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<FootballerService>().As<IFootballerService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<FootballerRepository>().As<IFootballerRepository>().InstancePerLifetimeScope();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS globally
app.UseCors("AllowAllOrigins");


app.UseAuthorization();

app.MapControllers();

app.Run();
