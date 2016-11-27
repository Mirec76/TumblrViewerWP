using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

namespace Tumblr.Common
{
    public static class InstanceFactory
    {
        private static ContainerBuilder containerBuilder;
        private static IContainer container;

        private static IDictionary<Type, Type> types;

        static InstanceFactory()
        {
            containerBuilder = new ContainerBuilder();
            types = new Dictionary<Type, Type>();
        }

        public static void RegisterType<TInterface, TClass>() where TClass : class, TInterface
        {
            containerBuilder.RegisterType<TClass>().As<TInterface>().SingleInstance();

            if (!types.ContainsKey(typeof(TInterface)))
                types.Add(typeof(TInterface), typeof(TClass));

        }

        public static void RegisterTypes<TClass>(IEnumerable<Type> interfaces)
        {
            var c = containerBuilder.RegisterType<TClass>();
            foreach (var type in interfaces)
                c.As(type);

            c.SingleInstance();
        }

        public static async Task<TInterface> GetInitilizedInstanceAsync<TInterface>()
        {
            var result = container.Resolve<TInterface>();
            var asyncInitializationObject = result as IAsyncInitialization;
            if (asyncInitializationObject != null && !asyncInitializationObject.IsInitialized)
                await asyncInitializationObject.Initialize();

            return result;
        }

        public static void RegisterWithTransientLifetime<TInterface, TClass>() where TClass : class, TInterface
        {
            containerBuilder.RegisterType<TClass>().As<TInterface>();
        }

        public static TInterface GetInstance<TInterface>(bool throwExceptionOnError = true)
        {
            try
            {
                return container.Resolve<TInterface>();
            }
            catch (Exception ex)
            {
                if (throwExceptionOnError)
                {
                    var type = typeof(TInterface);
                    var message = string.Format("Cannot resolve interface \"{0}\".", type.FullName);
                    var exc = new Exception(message, ex);
                    throw exc;
                }

                return default(TInterface);
            }
        }

        public static void Build()
        {
            container = containerBuilder.Build();
        }

        public static Type GetInstanceType<TInterface>()
        {
            if (types.ContainsKey(typeof(TInterface)))
                return types[typeof(TInterface)];

            return null;
        }
    }
}
