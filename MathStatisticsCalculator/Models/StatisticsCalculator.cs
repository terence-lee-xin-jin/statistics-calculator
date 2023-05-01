using System;
using System.Collections.Generic;


namespace Calculator
{

    /// <summary>
    /// Author: Terence Lee
    ///
    ///Purpose: Calculate the various statistics value of a list of numbers
    ///
    /// E.g.
    /// List<double> listOfNumbers = new List<double>()
    /// {
    /// 1,2,3,4,5
    /// }
    ///
    /// StatisticsCalculator calculator = new StatisticsCalculator(listOfNumbers);
    ///
    ///
    ///Console.WriteLine(calculator.Mean);
    /// Console.WriteLine(calculator.Median);
    /// Console.WriteLine(calculator.Mode);
    ///
    /// </summary>
    public class StatisticsCalculator
    {
        private List<double> listOfNumbers;

        public StatisticsCalculator(List<double> listOfNumbers) {
            
            if (listOfNumbers.Count == 0) 
            {
                throw new ArgumentException("list of numbers " +
                    "cannot have count of zero");
            }
            this.listOfNumbers = new List<double>(listOfNumbers);
            
            Calculate();
        }


   
        /// <summary>
        /// Calculate the various statistical values from 
        /// this.listOfNumbers
        /// </summary>
        private void Calculate()
        {
            this.listOfNumbers.Sort();
            this.CalculateCount();
            this.CalculateMin();
            this.CalculateMax();
            this.CalculateRange();
            this.CalculateSum();
            

            this.CalculateMean();
            this.CalculateMedian();
            this.CalculateModeAndModeAppearanceCount();


            this.CalculateVariance();
            this.CalculateStandardDeviation();
        }



        /// <summary>
        /// Calculate and set the Count (number of numbers in listOfNumbers)
        /// property and set value for the Count property
        /// </summary>
        private void CalculateCount()
        {
            this.Count = this.listOfNumbers.Count;
        }


        /// <summary>
        /// Set the Min (minimum property) and set value for the Min property
        /// 
        /// Pre-condition: the this.listOfNumbers must be sorted according
        /// to ascending order, with the smallest number at index 0
        /// </summary>
        private void CalculateMin()
        {
            this.Min = this.listOfNumbers[0];
        }




        /// <summary>
        /// Set the Max (minimum property) and set value for the Max property
        /// 
        /// Pre-condition: the this.listOfNumbers must be sorted according
        /// to ascending order, with the largest number at last index
        /// </summary>
        private void CalculateMax()
        {
            this.Max = this.listOfNumbers[listOfNumbers.Count - 1];
        }


        /// <summary>
        /// Calculate the difference between the smallest and largest
        /// number in this.listOfNumbers and set value for the Range property
        ///
        /// Pre-condition: the this.listOfNumbers must be sorted according
        /// to ascending order, with the smallest number at index 0
        /// </summary>
        private void CalculateRange()
        {
            this.Range = this.listOfNumbers[listOfNumbers.Count - 1]
                            - this.listOfNumbers[0];
        }



        /// <summary>
        /// Calculate the sum of all numbers in this.listOfNumbers
        /// and set value for the Sum property
        /// </summary>
        private void CalculateSum()
        {
            double sum = 0;

            foreach (double number in listOfNumbers) 
            {
                sum += number;
            }

            this.Sum = sum;
        }



        /// <summary>
        /// Calculate the mean of the numbers in this.listOfNumbers 
        /// and set value for the Mean property
        ///
        /// Pre-condition: this.Sum property must already be calculated
        /// and set
        /// </summary>
        private void CalculateMean()
        { 
            this.Mean = this.Sum / this.listOfNumbers.Count;
        }


        /// <summary>
        /// Calculate the median of the numbers in this.listOfNumbers
        /// and set value for the Median property
        ///
        /// Pre-condition: this.listOfNumbers must be sorted in ascending
        /// order with the smallest number at index 0
        /// </summary>
        private void CalculateMedian()
        {

            if (this.listOfNumbers.Count == 1)
            {
                this.Median = this.listOfNumbers[0];
            }
            else if (this.listOfNumbers.Count % 2 == 0)
            {
                int upperMidpointIndex = this.listOfNumbers.Count / 2;
                int lowerMidpointIndex = upperMidpointIndex - 1;

                this.Median = (this.listOfNumbers[upperMidpointIndex] +
                                this.listOfNumbers[lowerMidpointIndex]) / 2;
            }
            else
            {
                int midpointIndex = this.listOfNumbers.Count / 2;
                this.Median = this.listOfNumbers[midpointIndex];
            }
        }



        /// <summary>
        /// Calculate the mode of this.listOfNumbers, and also the number of
        /// times the mode appeared
        /// </summary>
        private void CalculateModeAndModeAppearanceCount()
        {
            Dictionary<double, int> numberToAppearanceCountDictionary =
                                new Dictionary<double, int>();

            int highestAppearanceCount = 1;

            foreach(double number in this.listOfNumbers)
            {
                int currentCount;

                if (!numberToAppearanceCountDictionary.ContainsKey(number))
                {
                    numberToAppearanceCountDictionary[number] =  1;

                    currentCount = 1;
                }
                else
                {
       
                    currentCount = numberToAppearanceCountDictionary[number];

                    currentCount++;

                    numberToAppearanceCountDictionary[number] = currentCount;
                }

                highestAppearanceCount = Math.Max(currentCount, highestAppearanceCount);
            }


            this.Mode = new List<double>();

            foreach(KeyValuePair<double, int> keyValuePair in  numberToAppearanceCountDictionary)
            {
                int appearanceCount = keyValuePair.Value;

                if (appearanceCount == highestAppearanceCount)
                {
                    this.Mode.Add(keyValuePair.Key);
                }
            }


            this.Mode.TrimExcess();
            this.ModeAppearanceCount= highestAppearanceCount;
        }


        /// <summary>
        /// Calculate the variance from this.listOfNumbers and
        /// set the value for the Variance property
        ///
        /// Pre-condition: this.Mean property must already be calculated
        /// and set
        /// </summary>

        private void CalculateVariance()
        {
            double sumOfSquareDifferences = 0;

            foreach(double number in this.listOfNumbers)
            {
                double difference = number - this.Mean;
                sumOfSquareDifferences += (difference * difference);

            }

            this.Variance = sumOfSquareDifferences / this.listOfNumbers.Count;

        }



        /// <summary>
        /// Calculate the standard deviation from this.listOfNumbers and
        /// set the value for the StandardDeviation property
        ///
        /// Pre-condition: this.StandardDeviation property must already 
        /// be calculated and set
        /// </summary>
        private void CalculateStandardDeviation()
        {
            this.StandardDeviation = Math.Sqrt(this.Variance);
        }



        /// <summary>
        /// The count (number of numbers in the list)
        /// </summary>
        public int Count
        {
            private set;
            get;
        }


        /// <summary>
        /// The smallest (minimum) value in the list of values
        /// </summary>
        public double Min
        {
            private set;
            get;
        }


        /// <summary>
        /// The largest (max) value in the list of values
        /// </summary>
        public double Max
        {
            private set;
            get;
        }


        /// <summary>
        /// The difference between the smallest and largest
        /// number in list Of numbers provided
        /// </summary>
        public double Range
        {
            private set;
            get;
        }



        /// <summary>
        /// The sum of all numbers in list Of numbers provided
        /// </summary>
        public double Sum
        {
            private set;
            get;
        }


        /// <summary>
        /// The mean of the list of numbers provided
        /// </summary>
        public double Mean
        {
            private set;
            get;
        }


        /// <summary>
        /// The median of the list of numbers provided
        /// </summary>
        public double Median
        {
            private set;
            get;
        }



  
        /// <summary>
        /// A list of numbers which are the mode
        /// </summary>
        public List<double> Mode
        {
            private set;
            get;
        }


        /// <summary>
        /// The number of times the mode appeared. E.g. if the number 7
        /// is the mode and it appeared 20 times, then the ModeAppearanceCount
        /// is 20
        /// </summary>
        public int ModeAppearanceCount
        {
            private set;
            get;
        }



        /// <summary>
        /// The varaince of the list of numbers
        /// </summary>
        public double Variance
        {
            private set;
            get;
        }


   
        /// <summary>
        /// The standard deviation of the list of numbers
        /// </summary>
        public double StandardDeviation
        {
            private set;
            get;
        }

        

       
    }
}
