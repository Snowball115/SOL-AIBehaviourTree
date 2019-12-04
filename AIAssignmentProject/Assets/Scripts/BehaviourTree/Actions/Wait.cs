using System.Collections;
using UnityEngine;

// ********************
// Waits for an amount of seconds
// ********************
public class Wait : LeafNode
{
    private float seconds;

    public Wait(float seconds)
    {
        this.seconds = seconds;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        yield return new WaitForSeconds(seconds);

        SetState(NodeState.SUCCESS);
    }
}
