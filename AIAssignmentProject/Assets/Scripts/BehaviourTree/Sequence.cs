using System.Collections;
using UnityEngine;

public class Sequence : CompositeNode
{
    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].SetState(NodeState.RUNNING);

            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                // Check if node fails
                if (childNodes[i].GetState() == NodeState.FAILURE)
                {
                    SetState(NodeState.FAILURE);
                    yield break;
                }

                // Evaluate the current node
                yield return childNodes[i].Evaluate();
            }
        }

        yield return null;

        SetState(NodeState.SUCCESS);

        Debug.Log(GetState().ToString());
    }
}