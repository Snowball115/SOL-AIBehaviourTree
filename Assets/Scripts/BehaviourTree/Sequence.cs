using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeNode
{
    public override NodeState Evaluate()
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            // Set own state to running while running through child nodes
            SetState(NodeState.RUNNING);

            // Check state of each node that we are evaluating
            switch (childNodes[i].Evaluate())
            {
                // Current node we are evaluating
                case NodeState.RUNNING:
                    continue;
                // Go to next node if previous node was successful
                case NodeState.SUCCESS:
                    continue;
                // Set own state to failure if one node fails
                case NodeState.FAILURE:
                    SetState(NodeState.FAILURE);
                    return currentState;
            }

            // Return state for the out of for-loop return state
            // this simply says if we are currently processing a node and when not, we are finished
            if (i < childNodes.Count) currentState = NodeState.RUNNING;
            else currentState = NodeState.SUCCESS;
        }

        return currentState;
    }
}