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

                isAnyNodeEvaluating = true;

                while (childNodes[i].GetState() == NodeState.RUNNING)
                {
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

            // Check if nodes are still evaluating
            if (isAnyNodeEvaluating) SetState(NodeState.RUNNING);
            else SetState(NodeState.SUCCESS);

            yield return null;
        }
    }
}