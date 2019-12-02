using System.Collections;
using UnityEngine;

public class Selector : CompositeNode
{
    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].SetState(NodeState.RUNNING);

            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                // Check if node successes
                if (childNodes[i].GetState() == NodeState.SUCCESS)
                {
                    SetState(NodeState.SUCCESS);
                    yield break;
                }

                //if (childNodes[i].GetState() == NodeState.FAILURE)
                //{
                //    continue;
                //}

                // Evaluate the current node
                yield return childNodes[i].Evaluate();
            }

            if (childNodes[i].GetState() == NodeState.SUCCESS) yield break;
        }

        SetState(NodeState.FAILURE);

        yield return null;
    }
}