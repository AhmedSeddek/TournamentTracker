using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }
        public PrizeModel(string placeNum, string placeName, string prizeAmount, string prizePercent)
        {
            int localPlaceNum = 0;
            int.TryParse(placeNum, out localPlaceNum);
            PlaceNumber = localPlaceNum;

            PlaceName = placeName;

            decimal localPrizeAmount = 0;
            decimal.TryParse(prizeAmount, out localPrizeAmount);
            PrizeAmount = localPrizeAmount;

            double localPrizePercent = 0;
            double.TryParse(prizePercent, out localPrizePercent);
            PrizePercentage = localPrizePercent;
        }
    }
}
