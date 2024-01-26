using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookingManagement.API.Filters;
using BookingManagement.API.Middleware;
using BookingManagement.API.Modules;
using BookingManagement.Core.Repositories;
using BookingManagement.Core.Services;
using BookingManagement.Core.UnitOfWorks;
using BookingManagement.Repository;
using BookingManagement.Repository.Repositories;
using BookingManagement.Repository.UnitOfWork;
using BookingManagement.Service.Mapping;
using BookingManagement.Service.Services;
using BookingManagement.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PlaceDtoValidator>());
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserBookingDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PlaceDtoValidator>());
builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserBookingDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
{
    //dinamik tip güvenli
    option.MigrationsAssembly(Assembly
        .GetAssembly(typeof(AppDbContext))
        .GetName().Name);
}));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
