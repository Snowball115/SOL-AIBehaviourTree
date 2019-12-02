using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if an given bool returns true, e.g. for carrying the flag
public class IsBoolTrue : LeafNode
{
    private bool boolToCheck;

    public IsBoolTrue(bool boolToCheck)
    {
        this.boolToCheck = boolToCheck;
    }

    protected override IEnumerator Execute()
    {
        if (!boolToCheck)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
