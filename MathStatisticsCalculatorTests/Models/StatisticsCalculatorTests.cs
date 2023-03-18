using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Models.Tests
{
    [TestClass()]
    public class StatisticsCalculatorTests
    {
        const double Delta = 0.0001;



        [TestMethod()]

        public void StatisticsCalculatorTest_ListOfSizeZero_ArgumentException()
        {
            List<double> emptyList = new List<double>();

            Assert.ThrowsException<ArgumentException>(
                () => new StatisticsCalculator(emptyList));

        }



        [DataRow(new double[] { 5, 7, 9 }, 3)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, 8)]
        [DataRow(new double[] { 3.2, 4.2, 5.2, 6.2, 7.2 }, 5)]
        [DataTestMethod()]
        public void CountPropertyTest_CorrectCount(
                                            double[] arrayOfNumbers,
                                            int expectedCount)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedCount, statisticsCalculator.Count);
        }



        [DataRow(new double[] { 5, 7, 9, 11, 13, 15, 1, 3 }, 1)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, -8)]
        [DataRow(new double[] { 3.2, 4.2, 5.2, 6.2, 7.2, 8.2, 1.2, 2.2 }, 1.2)]
        [DataTestMethod()]
        public void MinPropertyTest_CorrectMin(
                                            double[] arrayOfNumbers,
                                            double expectedMin)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedMin, statisticsCalculator.Min);
        }



        [DataRow(new double[] { 5, 7, 9, 11, 13, 15, 1, 3 }, 15)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, -1)]
        [DataRow(new double[] { 3.2, 4.2, 5.2, 6.2, 7.2, 8.2, 1.2, 2.2 }, 8.2)]
        [DataTestMethod()]
        public void MaxPropertyTest_CorrectMax(
                                            double[] arrayOfNumbers,
                                            double expectedMax)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedMax, statisticsCalculator.Max);
        }


        [DataRow(new double[] { 1, 2, 5, 7, 9, 11, 13, 15 }, 14)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, 7)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 4.2, 5.2, 6.2, 7.2, 9.2 }, 8)]
        [DataTestMethod()]
        public void RangePropertyTest_CorrectRange(
                                            double[] arrayOfNumbers,
                                            double expectedRange)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedRange, statisticsCalculator.Range,
                            Delta);
        }



        [DataRow(new double[] { 1, 2, 5, 7, 9, 11, 13, 15 }, 63)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, -36)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 4.2, 5.2, 6.2, 7.2, 9.2 }, 38.6)]
        [DataTestMethod()]
        public void SumPropertyTest_CorrectSum(
                                            double[] arrayOfNumbers,
                                            double expectedSum)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedSum, statisticsCalculator.Sum,
                            Delta);
        }



        [DataRow(new double[] { 1, 3, 5, 7, 9, 11, 13, 15 }, 8)]
        [DataRow(new double[] { -1, -2, -3, -4, -5, -6, -7, -8 }, -4.5)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 4.2, 5.2, 6.2, 7.2, 8.2 }, 4.7)]
        [DataTestMethod()]
        public void MeanPropertyTest_CorrectMean(
                                            double[] arrayOfNumbers,
                                            double expectedMean)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedMean, statisticsCalculator.Mean, Delta);
        }


        [DataRow(new double[] { 1, 3, 5, 7, 15, 9, 11, 13 }, 8)]
        [DataRow(new double[] { -4, -1, -2, -3, -5, -6, -7 }, -4)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 5.2, 6.2, 7.2, 8.2, 4.2 }, 4.7)]
        [DataTestMethod()]
        public void MedianPropertyTest_CorrectMedian(double[] arrayOfNumbers,
                                            double expectedMedian)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedMedian, statisticsCalculator.Median, Delta);
        }



        [DataRow(new double[] { 1, 2, 3, 4, 4, 5 }, new double[] { 4 })]
        [DataRow(new double[] { -1, -3, -3, -5, -7, -7 }, new double[] { -3, -7 })]
        [DataRow(new double[] { 1.2, 2.2, 2.2, 5.2, 6.2, 6.2, 8.2},
                                new double[] {2.2,6.6 })]
        [DataTestMethod()]
        public void ModePropertyTest_CorrectMode(double[] arrayOfNumbers,
                                            double [] expectedModeArray)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            List<double> expectedModeList = new List<double>();
            expectedModeList.AddRange(expectedModeArray);
           
    

            for(int index=0; index < expectedModeList.Count; index++) 
            {
                Assert.AreEqual(expectedModeList[index],
                                statisticsCalculator.Mode[index], Delta);
                Console.WriteLine(statisticsCalculator.Mode[index]);
            }

            Assert.AreEqual(expectedModeList.Count, 
                            statisticsCalculator.Mode.Count);
        }




        [DataRow(new double[] { 1, 2, 3, 4, 5 }, 1)]
        [DataRow(new double[] { -1, -5, -7, -7}, 2)]
        [DataRow(new double[] { 1.2, 5.2, 8.2,8.2,8.2 },3)]
        [DataTestMethod()]
        public void ModeAppearanceCountPropertyTest_CorrectModeAppearanceCount(
                                            double[] arrayOfNumbers,
                                            int expectedModeAppearanceCount)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);


            Assert.AreEqual(expectedModeAppearanceCount,
                            statisticsCalculator.ModeAppearanceCount);
        }




        [DataRow(new double[] { 1, 11, 17, 25,44, 51 }, 312.13888888889)]
        [DataRow(new double[] { -4, -1, -2, -3, -5, -6, 9, 11,15 }, 55.135802469136)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 5.2, 6.2, 7.2, 8.2, 4.2 }, 5.25)]
        [DataTestMethod()]
        public void VariancePropertyTest_CorrectVariance(double[] arrayOfNumbers,
                                            double expectedVariance)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            
            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedVariance, statisticsCalculator.Variance, 
                            Delta);
        }



        [DataRow(new double[] { 1, 11, 17, 25, 44, 51 }, 17.667452812697)]
        [DataRow(new double[] { -4, -1, -2, -3, -5, -6, 9, 11, 15 }, 7.4253486429349)]
        [DataRow(new double[] { 1.2, 2.2, 3.2, 5.2, 6.2, 7.2, 8.2, 4.2 }, 2.2912878474779)]
        [DataTestMethod()]
        public void StandardDeviationPropertyTest_CorrectStandardDeviation(double[] arrayOfNumbers,
                                            double expectedStandardDeviation)
        {
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.AddRange(arrayOfNumbers);
            

            StatisticsCalculator statisticsCalculator =
                                    new StatisticsCalculator(listOfNumbers);

            Assert.AreEqual(expectedStandardDeviation, statisticsCalculator.StandardDeviation,
                            Delta);
        }
    }
}