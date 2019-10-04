# BDIAgentArchitecture
The BDI agent architecture is based on Michael Bratman’s philosophical theory (Bratman 1987) that explains reasoning through the following attitudes: beliefs, desires and intentions. Consequently, a BDI agent is an autonomous agent that makes use of these three concepts for its functioning.
Travel Assistant Agent (TAA) that uses a Beliefs-Desires-Intentions (BDI) agent architecture for its decision-making process.

The BDI agent architecture is based on Michael Bratman’s philosophical theory (Bratman 1987) that explains reasoning through the following attitudes: beliefs, desires and intentions. Consequently, a BDI agent is an autonomous agent that makes use of these three concepts for its functioning. Let’s examine these concepts one by one:

* Beliefs are the agent’s model of the environment, basically what it believes to be true. It’s not knowledge as some of its beliefs might be false. This component of the BDI architecture is usually represented as a dataset of facts like breeze(1, 2), danger(2, 3), safe(0, 0), safe(0, 1) and so on.
* Desires represent the ideal state of the environment for the agent. Like in the human mind, these represent things we would like to see accomplished in the future. A desire might be realistic or not, as it occurs with human thinking, and may or may not be achievable. Desires can be mutually inclusive or exclusive.
* Intentions represent a subset of desires that the agent has taken as goals to be accomplished soon. These intentions cannot go against its beliefs—for instance, the agent cannot have an intention that makes it go through a dead zone or otherwise prevents it from reaching the goal that the intention represents. Such an intention would be discarded.
Beliefs consist of a fact dataset that’s updated during the agent’s lifetime. Regarding desires and intentions, a pair of questions arises: How do you select desires to become intentions, and how do you select later intentions to become agent actions? To answer this, I must present the two components of practical reasoning in the BDI model of the agent:

* Deliberation: This component deals with strategic thinking and decides what desires are to be accomplished now. The result is a set of intentions.
* Means-Ends Reasoning: This component deals with tactical planning and decides what actions should be performed to fulfill the set of committed intentions. The result is a set of plans and actions.

Afterward, a set of options is generated that eventually becomes desires and enters the desire dataset. In order to generate these options, the function looks at the belief dataset and the intention dataset. As a result, its takes as parameters the belief dataset, the desire dataset and the intention dataset: generateOptions (beliefs, desires, intentions). Why do you need intentions to generate options? Because you don’t want to generate options that contradict or go against the current set of intentions.

Using a filter function, the previously obtained desires are filtered and become intentions. To filter you usually exclude desires that aren’t realistic or are very hard to fulfill at the moment. The filter function would have the signature: filter (beliefs, desires, intentions). Finally, from the set of intentions and a means-ends reasoning approach an action is taken using the agent’s effectors (such as mechanical arms and screens).

To summarize, *BDI* is a paradigm and set of general principles, which can be used to design the architecture of a software system for decision making. You may be familiar with other design paradigms, such as three-tier architecture or Model-View-Controller for Web systems. Like these other paradigms, BDI is a general design aide rather than a well-defined prescriptive blueprint.
