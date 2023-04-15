using Autofac;
using TaskInforce.BLL.Interfaces;
using TaskInforce.BLL.Services;
using TaskInforce.DAL.Interfaces;
using TaskInforce.DAL.Models;
using TaskInforce.DAL.Repositories;

namespace TaskInforce.BLL.DiAutofac
{
    public class Container : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<URLRepository>().As<IRepository<Url>>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IRepository<User>>().SingleInstance();
            builder.RegisterType<UserRefreshTokenRepository>().As<IRepository<UserRefreshToken>>().SingleInstance();

            builder.RegisterType<URLService>().As<IURLService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
