using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using TrackerLibrary.DataAccess;


namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; } 
        public static void InitializeConnections(DatabaseType db) {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            if(db == DatabaseType.TextFile)
            {
                TextConnector txt = new TextConnector();
                Connection = txt;
            }
        }
        public static string CnnVal(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
