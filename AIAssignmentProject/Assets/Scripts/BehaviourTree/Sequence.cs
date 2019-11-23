using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeNode
{
    private bool isEvaluatingNode;

    public override NodeState Evaluate()
    {
        isEvaluatingNode = false;

        // Set own state to running while running through child nodes
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            //Debug.Log(string.Format("{0} {1}", i, childNodes[i].GetState().ToString()));
            
            // Run and check state of each node that we are evaluating
            switch (childNodes[i].Evaluate())
            {
                // Current node we are evaluating
                case NodeState.RUNNING:
                    isEvaluatingNode = true;
                    continue;

                // Go to next node if previous node was successful
                case NodeState.SUCCESS:
                    continue;

                // Set own state to failure if one node fails
                case NodeState.FAILURE:
                    SetState(NodeState.FAILURE);
                    return currentState;
            }
        }

        // Check if we are currently processing a node and when not, we are finished
        if (isEvaluatingNode) SetState(NodeState.RUNNING);
        else SetState(NodeState.SUCCESS);

        return currentState;
    }
}