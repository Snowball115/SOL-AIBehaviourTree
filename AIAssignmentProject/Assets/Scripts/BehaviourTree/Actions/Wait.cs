using System.Collections;
using UnityEngine;

// Waits for an amount of seconds
public class Wait : LeafNode
{
    private int seconds;

    public Wait(int seconds)
    {
        this.seconds = seconds;
    }

    protected override IEnumerator Execute()
    {
        yield return new WaitForSeconds(seconds);

        SetState(NodeState.SUCCESS);
    }
}
