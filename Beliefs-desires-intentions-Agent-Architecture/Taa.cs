using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Beliefs_desires_intentions_Agent_Architecture.EnumTypes;

namespace Beliefs_desires_intentions_Agent_Architecture
{
    // The Taa<T> class that represents the Travel Assistant Agent inherits from Bdi<T> and its constructor, and the inherited methods implementation
    public class Taa<T> : Bdi<T> where T : Dictionary<string, string>
    {
        public Taa(IEnumerable<Attitude<BeliefType, T>> beliefs) : base(beliefs)
        {
        }
        public T GetPlan(IEnumerable<Attitude<DesireType, T>> desires)
        {
            return MeansEndsReasoning(Deliberate(desires));
        }
        protected override IEnumerable<Attitude<IntentionType, T>> Deliberate(IEnumerable<Attitude<DesireType, T>> desires)
        {
            return LookForTours(desires.ToList());
        }

        //  in the MeansEndsReasoning method, to have a simple logic I returned the first feasible tour package as the holiday intention for the tourist.
        protected override T MeansEndsReasoning(IEnumerable<Attitude<IntentionType, T>> intentions)
        {
            return intentions.FirstOrDefault() == null ? null :
              intentions.First().AttitudeRepresentation;
        }

        // in this method that desires inputted by tourists seek possible satisfaction by being put against beliefs in the Beliefs dataset. Recall that in the sample model, each belief represents a tour package. If such a package is found, then it’s added to a result list of intentions, all of which consist of booking a certain tour package.
        private IEnumerable<Attitude<IntentionType, T>>  LookForTours<T>(List<Attitude<DesireType, T>> desires) where T : Dictionary<string, string>
        {
            var visitDesire = desires.First(d => d.Label == DesireType.Visit);
            var dateDesire = desires.First(d => d.Label == DesireType.Date);
            var maxBudgetDesire = desires.First(d => d.Label == DesireType.Budget);
            var citiesToVisit = visitDesire.AttitudeRepresentation["visiting"]
              .Split(',');
            var dateFrom = dateDesire.AttitudeRepresentation["from"];
            var days = int.Parse(dateDesire.AttitudeRepresentation["days"]);
            var maxBudget =
              double.Parse(maxBudgetDesire.AttitudeRepresentation["max"]);
            var tourPackages = Beliefs.Where(b => b.Label == BeliefType.TourPackages);
            var result = new List<Attitude<IntentionType, T>>();
            foreach (var tourPackage in tourPackages)
            {
                var data = tourPackage.AttitudeRepresentation as Dictionary<string, string>;
                var starts = data["starts"];
                var daysTour = int.Parse(data["days"]);
                var cities = data["cities"].Split(',');
                var price = double.Parse(data["price"]);
                if (daysTour <= days &&
                  cities.Intersect(citiesToVisit).Count() == cities.Length &&
                  starts == dateFrom &&
                  price < maxBudget)
                {
                    result.Add(new Attitude<IntentionType, T>(IntentionType.BookTourPackage,
                      tourPackage.AttitudeRepresentation as T));
                }
            }
            return result;
        }
    }
}
