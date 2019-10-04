using System;
using System.Collections.Generic;
using System.Text;

namespace Beliefs_desires_intentions_Agent_Architecture
{
    // EnumeTypes used as T parameter in BDI class
    public class EnumTypes
    {
        public enum DesireType
        {
            Visit, Budget, Date
        }
        public enum BeliefType
        {
            TourPackages
        }
        public enum IntentionType
        {
            BookTourPackage
        }
    }
}
