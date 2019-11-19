using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeNode
{
    public override void Evaluate()
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            // Set own state to running while running through child nodes
            SetState(NodeState.RUNNING);

            while (GetState() == NodeState.RUNNING)
            {
                childNodes[i].Evaluate();

                if (childNodes[i].GetState() == NodeState.FAILURE)
                {
                    // Skip to next child note if current node fails
                    i++;
                }
            }

            // Set own node to success if all nodes have been successfully evaluated
            SetState(NodeState.SUCCESS);
        } 
    }
}