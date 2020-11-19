using System;
using System.Collections.Generic;
using System.IO;
//using System.Diagnostics.Debug.Write

namespace BudapestAirportFileApp
{
    public class BudapestAirportFileApp
    {
        private static string filePath = @"D:\VS Repos\BudapestAirportApp\Files\input.txt";
        private static char[] delimiterChars = { ' ', '\t' };
        private static List<(string, string, string)> budapestAirportData = new List<(string, string, string)>();
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
                budapestAirportData.Add((splitWords[0], splitWords[1], splitWords[2]));
                splitWords.Clear();
            }
        }

        static string Exercise1()
        {
            int counter = 0;

            foreach (var outboundFlihgt in budapestAirportData)
            {
                if (outboundFlihgt.Item2.Contains("Frankfurt"))
                    counter++;               
            }

            return counter.ToString();
        }

        static string Exercise2()
        {
            int listIndex = 0;
            int biggerPassangersNumber = 0;
            string result;

            for (int i = 0; i < budapestAirportData.Count; i++)
            {
                if (Int32.Parse(budapestAirportData[i].Item3) > biggerPassangersNumber)
                {
                    biggerPassangersNumber = Int32.Parse(budapestAirportData[i].Item3);
                    listIndex = i;
                }
            }

            result = budapestAirportData.Count != 0 ? budapestAirportData[listIndex].Item1 + " " + budapestAirportData[listIndex].Item2 + " " + budapestAirportData[listIndex].Item3 : emptyDataMessage;

            return result;
        }



        static string Exercise3()
        {
            int listIndex = 0;
            bool thereIslessThan100 = false;
            string result;

            for (int i = 0; i < budapestAirportData.Count; i++)
            {
                if (Int32.Parse(budapestAirportData[i].Item3) < 100)
                {
                    listIndex = i;
                    thereIslessThan100 = true;
                    break;
                }                   
            }

            result = thereIslessThan100 ? budapestAirportData[listIndex].Item1 + " " + budapestAirportData[listIndex].Item2 + " " + budapestAirportData[listIndex].Item3 : nolessthan100Message;

            return result;
        }

        static string Exercise4()
        {
            Dictionary<string, int> airlinesVsPassengers = new Dictionary<string, int>();
            string result;
            string higherAirLineWithMostPassengers ="";
            int higherPassengersNumber = 0;

            foreach (var outboundFlight in budapestAirportData)
            {
                if (!airlinesVsPassengers.ContainsKey(outboundFlight.Item1))
                {
                    airlinesVsPassengers.Add(outboundFlight.Item1, Int32.Parse(outboundFlight.Item3));
                }
                else
                {
                    airlinesVsPassengers[outboundFlight.Item1] = airlinesVsPassengers[outboundFlight.Item1] + Int32.Parse(outboundFlight.Item3);
                }

                if (airlinesVsPassengers[outboundFlight.Item1] > higherPassengersNumber)
                {
                    higherAirLineWithMostPassengers = outboundFlight.Item1;
                    higherPassengersNumber = airlinesVsPassengers[outboundFlight.Item1];
                }
                 
            }

            result = budapestAirportData.Count != 0 ? higherAirLineWithMostPassengers + " " + airlinesVsPassengers[higherAirLineWithMostPassengers].ToString() : emptyDataMessage;

            return result;
        }


        static void Main (string[] args)
        {
            ClassifyData();
            Console.Out.WriteLine(Exercise1() + '\n' + Exercise2() + '\n' + Exercise3() + '\n' + Exercise4());
        }


    }
}
