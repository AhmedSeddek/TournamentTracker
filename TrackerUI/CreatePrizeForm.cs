using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.Interfaces;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                PrizeModel model = new PrizeModel(placeNumberValue.Text,
                    placeNameValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                ClearInput();
            }
            else {
                MessageBox.Show("invalid input");
            }
        }
        private void ClearInput() {
            placeNumberValue.Text = "";
            placeNameValue.Text = "";
            prizeAmountValue.Text = "0";
            prizePercentageValue.Text = "0";

        }
        private bool Validation() {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValid = int.TryParse(placeNumberValue.Text, out placeNumber);
            if (!placeNumberValid && placeNumber < 1) {
                output = false;
            }
            if (placeNameLabel.Text.Length == 0) {
                output = false;
            }

            decimal prizeAmount = 0;
            int prizePercent = 0;
            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentValid = int.TryParse(prizePercentageValue.Text, out prizePercent);
            if (!prizeAmountValid || !prizePercentValid) {
                output = false;
            }
            if (prizePercent < 0 || prizePercent > 100) {
                output = false;
            }


            return output;
        }
    }
}
