using System;
using ShopLibrary;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShop.DataAccess;

namespace ShopLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static void InitializeConnection(bool databaseSQL)
        {
            if (databaseSQL == true)
            {
                SqlConnector sql = new SqlConnector();
                Connections.Add((IDataConnection)sql);
            }
        }

        public static string ConectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
