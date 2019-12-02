using System.Collections;
using UnityEngine;

// Compares if two positions are on the same location, e.g. is the flag in base currently
public class ComparePosition : LeafNode
{
    private Vector3 posA;
    private Vector3 posB;
    private float tolerance;

    public ComparePosition(Vector3 posA, Vector3 posB, float tolerance)
    {
        this.posA = posA;
        this.posB = posB;
        this.tolerance = tolerance;
    }

    protected override IEnumerator Execute()
    {
        if (Vector3.Distance(posA, posB) > tolerance)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
