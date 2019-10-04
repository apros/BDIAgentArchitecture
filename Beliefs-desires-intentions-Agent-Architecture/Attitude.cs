using System;
using System.Collections.Generic;
using System.Text;

namespace Beliefs_desires_intentions_Agent_Architecture
{
    // comprehend all characteristics of any attitude (belief, desire, intention) in a BDI agent architecture
    public class Attitude<TA, T>
    {
        public T AttitudeRepresentation;
        public TA Label;
        public Attitude(TA label, T attitudeRepr)
        {
            Label = label;
            AttitudeRepresentation = attitudeRepr;
        }
    }
}
