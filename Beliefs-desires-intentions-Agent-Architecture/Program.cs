using System;
using System.Collections.Generic;
using static Beliefs_desires_intentions_Agent_Architecture.EnumTypes;

namespace Beliefs_desires_intentions_Agent_Architecture
{
    class Program
    {
        // Application based on MSDN magazine's article: https://msdn.microsoft.com/en-us/magazine/mt848706
        static void Main(string[] args)
        {
            var beliefs = new List<Attitude<BeliefType, Dictionary<string, string>>>
              {
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Essential-Cuba" },
                  { "starts" , "Anytime" }, { "days" , "7"}, { "cities", "HAV, VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Cuba Beaches Holiday" },
                  { "starts", "10-12-2018" }, { "days" , "8"}, { "cities", "HAV, VAR" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Havana & Varadero Tour" },
                  { "starts", "12-15-2018" }, { "days" , "15"}, { "cities", "HAV,VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Discover Cuba" },
                  { "starts", "12-15-2018" }, { "days", "15"}, { "cities", "HAV, VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Classic Car Tour" },
                  { "starts", "12-15-2018" }, { "days", "10"}, { "cities", "HAV,VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Havana Explorer" },
                  { "starts", "12-15-2018" }, { "days", "3"}, { "cities", "HAV, VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
                new Attitude<BeliefType, Dictionary<string, string>>(
                  BeliefType.TourPackages,
                  new Dictionary<string, string> { { "tour", "Trinidad Time" },
                  { "starts", "12-15-2018" }, { "days", "7"}, { "cities", "HAV,VAR, TRI" },
                  { "price" , "800"}, { "operator" , "www.cubamaniatour.com" }}),
              };
            var taa = new Taa<Dictionary<string, string>>(beliefs);
            var desires = new List<Attitude<DesireType, Dictionary<string, string>>>
              {
                new Attitude<DesireType, Dictionary<string, string>>(DesireType.Visit,
                  new Dictionary<string, string> { {"visiting", "HAV, VAR" } }),
                new Attitude<DesireType, Dictionary<string, string>>(DesireType.Budget,
                  new Dictionary<string, string> { {"max", "1000" } }),
                new Attitude<DesireType, Dictionary<string, string>>(DesireType.Date,
                  new Dictionary<string, string> { {"from", "10-12-2018" },
                    {"days" , "9"  }})
              };
            var tourPackage = taa.GetPlan(desires);
            Console.WriteLine(tourPackage == null ?
              "Sorry, no plan goes according to your details" : PrintPlan(tourPackage));
            Console.ReadLine();
        }

        private static string PrintPlan(Dictionary<string, string> toPrint)
        {
            var result = "";
            foreach (var keyValue in toPrint)
            {
                result += keyValue.Key + ", " + keyValue.Value + '\n';
            }
            return result;
        }
    }
}

