//Author: Gage Riley
//ID: 598483
//Date: 11/20/2017
//Goal-Purpose of the Program: This program calculates and compares the 5 year total cost of 2 different cars using methods passing single/multiple parameters.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace costMethods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //these are my constant/fixed variables
        const decimal MilesPerYear = 12000;
        const decimal CostOfFuel = 2.50m;
        

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //these are my variables that hold the numeric version of what a user typed in
            decimal MPGCar1InDec = 0;
            decimal PurchaseCar1InDec = 0;
            decimal RepairCar1InDec = 0;
            decimal InsuranceCar1InDec = 0;

            decimal MPGCar2InDec = 0;
            decimal PurchaseCar2InDec = 0;
            decimal RepairCar2InDec = 0;
            decimal InsuranceCar2InDec = 0;

            //these are my variables to hold the results of calcuations
            decimal TotalAllCostCar1Dec = 0;
            decimal TotalAllCostCar2Dec = 0;

            decimal my1YearFuelCostCar1;
            decimal my1YearFuelCostCar2;

            bool myTryParseResultBool;

            //INPUT /validation for data
            myTryParseResultBool = decimal.TryParse(MPGCar1Box.Text, out MPGCar1InDec);

            if (myTryParseResultBool == false)
            {

                MPGCar1Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                MPGCar1Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(PurchaseCar1Box.Text, out PurchaseCar1InDec);

            if (myTryParseResultBool == false)
            {

                PurchaseCar1Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                PurchaseCar1Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(RepairCar1Box.Text, out RepairCar1InDec);

            if (myTryParseResultBool == false)
            {

                RepairCar1Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                RepairCar1Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(InsuranceCar1Box.Text, out InsuranceCar1InDec);

            if (myTryParseResultBool == false)
            {

                InsuranceCar1Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                InsuranceCar1Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(MPGCar2Box.Text, out MPGCar2InDec);

            if (myTryParseResultBool == false)
            {

                MPGCar2Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                MPGCar2Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(PurchaseCar2Box.Text, out PurchaseCar2InDec);

            if (myTryParseResultBool == false)
            {

                PurchaseCar2Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                PurchaseCar2Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(RepairCar2Box.Text, out RepairCar2InDec);

            if (myTryParseResultBool == false)
            {

                RepairCar2Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                RepairCar2Box.Focus();
                return;

            }

            myTryParseResultBool = decimal.TryParse(InsuranceCar2Box.Text, out InsuranceCar2InDec);

            if (myTryParseResultBool == false)
            {

                InsuranceCar2Box.Text = "";

                MessageBox.Show("Error: Enter correct input.");

                InsuranceCar2Box.Focus();
                return;

            }

            //PROCESSING
            //this performs the calculations using the numeric variables and saves it in local variables
            
            //call to for methods passing 1 parameter for 1 year fuel cost for each car
            my1YearFuelCostCar1 = GageRileyMETHODCalc1YearFuelCostCar1(MPGCar1InDec);
            my1YearFuelCostCar2 = GageRileyMETHODCalc1YearFuelCostCar2(MPGCar2InDec);

            //call to for method passing multiple paramaters for total cost of each car
            GageRileyMETHODCalcTotalCost(PurchaseCar1InDec, my1YearFuelCostCar1, RepairCar1InDec, InsuranceCar2InDec, PurchaseCar2InDec, my1YearFuelCostCar2, RepairCar2InDec, InsuranceCar2InDec, out TotalAllCostCar1Dec, out TotalAllCostCar2Dec);

            //TotalAllCostCar1Dec = ((PurchaseCar1InDec) + (5 * my1YearFuelCostCar1) + (5 * RepairCar1InDec) + (5 * InsuranceCar2InDec));
            //TotalAllCostCar2Dec = ((PurchaseCar2InDec) + (5 * my1YearFuelCostCar2) + (5 * RepairCar2InDec) + (5 * InsuranceCar2InDec));

            //OUTPUT
            //this converts the numeric data into text for output on the Windows form
            FuelTotalCar1Label.Text = my1YearFuelCostCar1.ToString("C");
            AllTotalCar1Label.Text = TotalAllCostCar1Dec.ToString("C");

            FuelTotalCar2Label.Text = my1YearFuelCostCar2.ToString("C");
            AllTotalCar2Label.Text = TotalAllCostCar2Dec.ToString("C");

            //IF-ELSE
            //this highlights the 5 year total cost label red for the car with the higher 5 year total cost
            if (TotalAllCostCar1Dec > TotalAllCostCar2Dec)
            {
                AllTotalCar1Label.BackColor = Color.Red;
                AllTotalCar2Label.BackColor = Color.Transparent;
            }

            else
            {
                AllTotalCar1Label.BackColor = Color.Transparent;
                AllTotalCar2Label.BackColor = Color.Red;
            }

        }

        //method for 1 year fuel cost for car 1
        private decimal GageRileyMETHODCalc1YearFuelCostCar1(decimal passINmpgcar1)
        {

            decimal local_1YearFuelCostDec;

            local_1YearFuelCostDec = (MilesPerYear / passINmpgcar1) * CostOfFuel;

            return local_1YearFuelCostDec;

        }

        //method for 1 year fuel cost for car 2
        private decimal GageRileyMETHODCalc1YearFuelCostCar2(decimal MPGCar2InDec)
        {

            decimal local_1YearFuelCostDec;

            local_1YearFuelCostDec = (MilesPerYear / MPGCar2InDec) * CostOfFuel;

            return local_1YearFuelCostDec;

        }

        //method for total cost for car 1 and car 2
        private void GageRileyMETHODCalcTotalCost(decimal passINcar1price, decimal passINcar1fuelcost, decimal passINcar1repaircost, decimal passINcar1insurancecost, decimal passINcar2price, decimal passINcar2fuelcost, decimal passINcar2repaircost, decimal passINcar2insurancecost, out decimal passOUTcar1totalcost, out decimal passOUTcar2totalcost)
        {

            passOUTcar1totalcost = ((passINcar1price) + (5 * passINcar1fuelcost) + (5 * passINcar1repaircost) + (5 * passINcar1insurancecost));
            passOUTcar2totalcost = ((passINcar2price) + (5 * passINcar2fuelcost) + (5 * passINcar2repaircost) + (5 * passINcar2insurancecost));
        }

    }
}
