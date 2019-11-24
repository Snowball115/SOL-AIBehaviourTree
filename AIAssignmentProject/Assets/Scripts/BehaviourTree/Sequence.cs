using System.Collections;
using UnityEngine;

public class Sequence : CompositeNode
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

                while (childNodes[i].GetState() == NodeState.RUNNING)
                {
                    isAnyNodeEvaluating = true;

                    // Check if node fails
                    if (childNodes[i].GetState() == NodeState.FAILURE)
                    {
                        SetState(NodeState.FAILURE);
                        yield break;
                    }

                    // Evaluate the current node
                    else
                    {
                        yield return childNodes[i].Evaluate();
                    }
                }

                if (childNodes[i].GetState() == NodeState.FAILURE) yield break;
            }

            //// Check if nodes are still evaluating so we dont exit this CompositeNode too early
            //if (isAnyNodeEvaluating) SetState(NodeState.RUNNING);
            //else SetState(NodeState.SUCCESS);

            yield return null;
        }
    }
}