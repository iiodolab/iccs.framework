using Autofac;
using StackExchange.Redis;

/******************************************************************************
 * Class RedisModule
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/
namespace Iodo.Iccs.Framework.Modules
{
    public class RedisModule : Module
    {
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.Register(ctx =>
                {
                    var host = $"{IpAddressRedis}:{PortRedis}";
                    var configuration = ConfigurationOptions.Parse(host);
                    configuration.AllowAdmin = true;
                    configuration.Password = PasswordRedis;
                    return ConnectionMultiplexer.Connect(configuration).GetSubscriber();
                })
                .As<ISubscriber>()
                .SingleInstance();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region - Properties -
        public string IpAddressRedis { get; set; }
        public int PortRedis { get; set; }
        public string PasswordRedis { get; set; }
        #endregion
    }
}
