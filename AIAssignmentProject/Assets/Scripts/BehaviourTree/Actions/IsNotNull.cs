using System.Collections;
using UnityEngine;

// ********************
// Check if an object is not null
// ********************
public class IsNotNull : LeafNode
{
    private GameObject objectToCheck;

    public IsNotNull(GameObject objectToCheck)
    {
        this.objectToCheck = objectToCheck;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        if (objectToCheck == null)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
