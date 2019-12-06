using System.Collections;
using UnityEngine;

// ******************
// Sequence: Iterates through nodes until one success
// ******************
public class Selector : CompositeNode
{
    protected override IEnumerator Execute()
    {
        //Debug.Log("ENTERING SELECTOR");

        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].SetState(NodeState.RUNNING);

            // Evaluate node while its running
            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                //// Check if node successes and exit while loop
                //if (childNodes[i].GetState() == NodeState.SUCCESS)
                //{
                //    SetState(NodeState.SUCCESS);
                //    Debug.Log("SUCESS ONE");
                //    yield break;
                //}

                // Evaluate the current node
                yield return childNodes[i].Evaluate();
            }

            //// Continue evaluating if one node fails
            //if (childNodes[i].GetState() == NodeState.FAILURE)
            //{
            //    continue;
            //}

            // Exit condition
            if (childNodes[i].GetState() == NodeState.SUCCESS)
            {
                //Debug.Log("SELECTOR SUCCESS");
                SetState(NodeState.SUCCESS);
                yield break;
            }
        }

        SetState(NodeState.FAILURE);

        yield return null;
    }
}