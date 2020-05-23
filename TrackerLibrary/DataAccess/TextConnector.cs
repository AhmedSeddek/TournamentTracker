using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public PrizeModel CreatePrize(PrizeModel model)
        {
            return model;
        }
    }
}

