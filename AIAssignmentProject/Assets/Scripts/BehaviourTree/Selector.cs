using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeNode
{
    public override IEnumerator Evaluate()
    {
        SetState(NodeState.RUNNING);

        while (currentState == NodeState.RUNNING)
        {
            isAnyNodeEvaluating = false;

            for (int i = 0; i < childNodes.Count; i++)
            {
                childNodes[i].SetState(NodeState.RUNNING);

                isAnyNodeEvaluating = true;

                while (childNodes[i].GetState() == NodeState.RUNNING)
                {
                    if (childNodes[i].GetState() == NodeState.SUCCESS)
                    {
                        SetState(NodeState.SUCCESS);
                        yield break;
                    }

                    else
                    {
                        yield return childNodes[i].Evaluate();
                    }
                }

                if (childNodes[i].GetState() == NodeState.SUCCESS) yield break;
            }

            // Check if nodes are still evaluating
            if (isAnyNodeEvaluating) SetState(NodeState.RUNNING);
            else SetState(NodeState.FAILURE);

            yield return null;
        }
    } 
}