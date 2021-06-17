using System;
using System.Collections.Generic;
using System.IO;

namespace BudapestAirportFileApp
{
    class Problem1
    {

        //private static string filePath = @"D:\VS Repos\BudapestAirportApp\Files\input.txt";
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\input.txt";
        private static char[] delimiterChars = { ' ', '\t' };
        //private static List<(string, string, string)> budapestAirportData = new List<(string, string, string)>();
        private static List<string> budapestAirportData_AirlineName = new List<string>();
        private static List<string> budapestAirportData_flightDestination = new List<string>();
        private static List<string> budapestAirportData_NumberOfPassengers = new List<string>();
        private const string nolessthan100Message = "There is no flight with passengers less than 100";
        private const string emptyDataMessage = "The file is empty!";


        static void ClassifyData()
        {
            string[] words;
            List<string> splitWords = new List<string>();
            string[] fileContent = File.ReadAllLines(filePath);

            foreach (var fileLine in fileContent)
            {
                words = fileLine.Split(delimiterChars);

                foreach (var word in words)
                {
                    //length 0 means null string
                    if (word.Length != 0)
                        splitWords.Add(word);

                }

                budapestAirportData_AirlineName.Add(splitWords[0]);
                budapestAirportData_flightDestination.Add(splitWords[1]);
                budapestAirportData_NumberOfPassengers.Add(splitWords[2]);

                splitWords.Clear();
            }
        }

        static string Exercise1()
        {
            int counter = 0;

            foreach (var outboundFlihgt in budapestAirportData_flightDestination)
            {
                if (outboundFlihgt.Contains("Frankfurt"))
                    counter++;
            }

            return counter.ToString();
        }

        static string Exercise2()
        {
            int listIndex = 0;
            int biggerPassangersNumber = 0;
            string result;

            for (int i = 0; i < budapestAirportData_NumberOfPassengers.Count; i++)
            {
                if (Int32.Parse(budapestAirportData_NumberOfPassengers[i]) > biggerPassangersNumber)
                {
                    biggerPassangersNumber = Int32.Parse(budapestAirportData_NumberOfPassengers[i]);
                    listIndex = i;
                }
            }

            result = budapestAirportData_NumberOfPassengers.Count != 0 ? budapestAirportData_AirlineName[listIndex] + " " + budapestAirportData_flightDestination[listIndex] + " " + budapestAirportData_NumberOfPassengers[listIndex] : emptyDataMessage;

            return result;
        }

        static string Exercise3()
        {
            int listIndex = 0;
            bool thereIslessThan100 = false;
            string result;

            for (int i = 0; i < budapestAirportData_NumberOfPassengers.Count; i++)
            {
                if (Int32.Parse(budapestAirportData_NumberOfPassengers[i]) < 100)
                {
                    listIndex = i;
                    thereIslessThan100 = true;
                    break;
                }
            }

            result = thereIslessThan100 ? budapestAirportData_AirlineName[listIndex] + " " + budapestAirportData_flightDestination[listIndex] + " " + budapestAirportData_NumberOfPassengers[listIndex] : nolessthan100Message;

            return result;
        }

        static string Exercise4()
        {
            Dictionary<string, int> airlinesVsPassengers = new Dictionary<string, int>();
            string result;
            string higherAirLineWithMostPassengers = "";
            int higherPassengersNumber = 0;

            for (int i = 0; i < budapestAirportData_AirlineName.Count; i++)
            {
                if (!airlinesVsPassengers.ContainsKey(budapestAirportData_AirlineName[i]))
                {
                    airlinesVsPassengers.Add(budapestAirportData_AirlineName[i], Int32.Parse(budapestAirportData_NumberOfPassengers[i]));
                }
                else
                {
                    airlinesVsPassengers[budapestAirportData_AirlineName[i]] = airlinesVsPassengers[budapestAirportData_AirlineName[i]] + Int32.Parse(budapestAirportData_NumberOfPassengers[i]);
                }

                if (airlinesVsPassengers[budapestAirportData_AirlineName[i]] > higherPassengersNumber)
                {
                    higherAirLineWithMostPassengers = budapestAirportData_AirlineName[i];
                    higherPassengersNumber = airlinesVsPassengers[budapestAirportData_AirlineName[i]];
                }
            }

            result = budapestAirportData_NumberOfPassengers.Count != 0 ? higherAirLineWithMostPassengers + " " + airlinesVsPassengers[higherAirLineWithMostPassengers].ToString() : emptyDataMessage;

            return result;
        }


        static void Main(string[] args)
        {
            ClassifyData();
            Console.Out.WriteLine(Exercise1() + '\n' + Exercise2() + '\n' + Exercise3() + '\n' + Exercise4());//
        }

    }
}
