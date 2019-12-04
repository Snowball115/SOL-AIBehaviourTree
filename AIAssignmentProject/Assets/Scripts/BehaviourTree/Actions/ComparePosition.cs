using System.Collections;
using UnityEngine;

// Compares if two positions are on the same location, e.g. is the flag in base currently
public class ComparePosition : LeafNode
{
    private GameObject posA;
    private GameObject posB;
    private float tolerance;

    public ComparePosition(GameObject posA, GameObject posB, float tolerance)
    {
        this.posA = posA;
        this.posB = posB;
        this.tolerance = tolerance;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        if (Vector3.Distance(posA.transform.position, posB.transform.position) > tolerance)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
