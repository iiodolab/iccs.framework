using Autofac;
using System.Data;
using System.Data.SQLite;

/******************************************************************************
 * Class DBConnectionModule
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Modules
{
    public class DBConnectionModule : Module
    {
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.Register(ctx =>
                {   
                    string conns = @$"{PathDatabase}";
                    var dataSource = @$"Data Source={conns}; Version={Version};";
                    return new SQLiteConnection(dataSource);
                })
                .As<SQLiteConnection>()
                .As<IDbConnection>()
                .SingleInstance();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region - Properties -
        public string PathDatabase { get; set; }
        public int Version { get; set; }
        #endregion

        #region - Attributes -
        #endregion
    }
}
