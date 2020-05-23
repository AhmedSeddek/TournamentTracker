using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TrackerLibrary.Connectors;
using TrackerLibrary.Interfaces;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static void InitializeConnections(bool database, bool datatext) {
            if (database)
            {
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }
            if(datatext)
            {
                TextConnector txt = new TextConnector();
                Connections.Add(txt);
            }
        }
    }
}
