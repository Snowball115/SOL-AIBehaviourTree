using System.Collections;
using UnityEngine;

public class Sequence : CompositeNode
{
    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            // Evaluate node while its running
            childNodes[i].SetState(NodeState.RUNNING);

            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                // Check if node fails and exit while loop
                if (childNodes[i].GetState() == NodeState.FAILURE)
                {
                    SetState(NodeState.FAILURE);
                    yield break;
                }

                // Evaluate the current node
                yield return childNodes[i].Evaluate();
            }

            // Exit condition for outer loop
            if (childNodes[i].GetState() == NodeState.FAILURE) 
            {
                //Debug.Log("SEQUENCE FAILED");
                yield break;
            }
        }
        
        SetState(NodeState.SUCCESS);

        yield return null;
    }
}