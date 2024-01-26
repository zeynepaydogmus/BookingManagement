﻿using Autofac;
using BookingManagement.Caching;
using BookingManagement.Core.Repositories;
using BookingManagement.Core.Services;
using BookingManagement.Core.UnitOfWorks;
using BookingManagement.Repository;
using BookingManagement.Repository.Repositories;
using BookingManagement.Repository.UnitOfWork;
using BookingManagement.Service.Mapping;
using BookingManagement.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace BookingManagement.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            builder
                .RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
          .RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
          .Where(x => x.Name.EndsWith("Service"))
          .AsImplementedInterfaces()
          .InstancePerLifetimeScope();

            builder
                .RegisterType<UserBookingServiceWithCaching>().As<IUserBookingService>();


        }
    }
}
