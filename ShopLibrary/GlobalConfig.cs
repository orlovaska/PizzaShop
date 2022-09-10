﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Connections.Add(sql);
            }
        }
    }
}
