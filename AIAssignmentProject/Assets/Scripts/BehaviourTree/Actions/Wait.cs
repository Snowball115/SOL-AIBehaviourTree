using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
