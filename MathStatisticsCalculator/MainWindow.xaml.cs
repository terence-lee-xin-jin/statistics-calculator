using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Calculator;


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeButtons();
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitializeButtons()
        {
            this.calculateButton.Click += 
                    (sender, args) => CalculateAndDisplayStatisticsValues();

            this.userInputNumbersTextBox.TextChanged +=
                    (senders, args) => ResetResultValues();
        }


        private void CalculateAndDisplayStatisticsValues()
        {
            try
            {
                ResetResultValues();
                List<double> listOfNumbers = ConvertCommaSeparatedUserInputToList();

                StatisticsCalculator statisticsCalculator = new StatisticsCalculator(listOfNumbers);
                DisplayStatisticsCalculationResults(statisticsCalculator);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid numbers entered, or the numbers are " +
                    "not separated using commas.", "Error");
            }
        }



        /// <summary>
        /// Converts a list of comma-separated values entered by the
        /// user into a list of doubles
        /// </summary>
        /// <returns>
        ///     a list of doubles containing the numbers entered by
        ///     the user
        /// </returns>
        private List<double> ConvertCommaSeparatedUserInputToList()
        {
            string userInputNumbers = this.userInputNumbersTextBox.Text;

            userInputNumbers = userInputNumbers.Trim();

            //if the user entered comma as the last character,
            //remove the last character from the string
            if (userInputNumbers[userInputNumbers.Length - 1] == ',')
            {
                userInputNumbers =
                    userInputNumbers.Remove(userInputNumbers.Length - 1);
            }

            string[] userInputNumbersStringArray = userInputNumbers.Split(',');

            List<double> listOfNumbers = 
                    new List<double>(userInputNumbersStringArray.Length);


            foreach (string numberString in userInputNumbersStringArray)
            {
                string trimmedNumberString = numberString.Trim();
                listOfNumbers.Add(Convert.ToDouble(trimmedNumberString));
            }

            listOfNumbers.TrimExcess();

            return listOfNumbers;
        }



        


        /// <summary>
        /// Display the statistical results after calculation
        /// </summary>
        /// <param name="statisticsCalculator">
        ///     an instance of StatisticsCalculator containing the
        ///     results of statistics calculation
        /// </param>
        private void DisplayStatisticsCalculationResults(StatisticsCalculator statisticsCalculator)
        {
            this.countTextBlock.Text = statisticsCalculator.Count.ToString();
            this.minTextBlock.Text = statisticsCalculator.Min.ToString();
            this.maxTextBlock.Text = statisticsCalculator.Max.ToString();

            this.rangeTextBlock.Text = statisticsCalculator.Range.ToString();
            this.sumTextBlock.Text = statisticsCalculator.Sum.ToString();
            

            this.meanTextBlock.Text = statisticsCalculator.Mean.ToString();
            this.medianTextBlock.Text = statisticsCalculator.Median.ToString();
            this.displayModeValue(statisticsCalculator);


            this.varianceTextBlock.Text = statisticsCalculator.Variance.ToString();
            this.standardDeviationTextBlock.Text = statisticsCalculator.StandardDeviation.ToString();
  
        }


        /// <summary>
        /// Display the mode of the statistical results
        /// </summary>
        /// <param name="statisticsCalculator">
        /// an instance of StatisticsCalculator containing the
        ///     results of statistics calculation
        /// </param>
        private void displayModeValue(StatisticsCalculator statisticsCalculator)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for(int index=0; index < statisticsCalculator.Mode!.Count; index++) 
            {
                stringBuilder.Append(statisticsCalculator.Mode![index]);

                //if not the last number, append a comma
                if (index != statisticsCalculator.Mode!.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            if (statisticsCalculator.Mode!.Count == 1)
            {
                stringBuilder.Append(
                $" (appeared {statisticsCalculator.ModeAppearanceCount} times)");
            }
            else
            {
                stringBuilder.Append(
                $" (each appeared {statisticsCalculator.ModeAppearanceCount} times)");
            }
            

            this.modeTextBlock.Text =  stringBuilder.ToString();
        }


        /// <summary>
        /// Reset all the result fields to display only "-" (dash)
        /// </summary>
        private void ResetResultValues()
        {
            this.meanTextBlock.Text = "-";
            this.medianTextBlock.Text = "-";
            this.modeTextBlock.Text = "-";

            this.countTextBlock.Text = "-";
            this.sumTextBlock.Text = "-";
            this.rangeTextBlock.Text = "-";
            this.minTextBlock.Text = "-";
            this.maxTextBlock.Text = "-";

            this.varianceTextBlock.Text = "-";
            this.standardDeviationTextBlock.Text = "-";
        }


        


    }
}
