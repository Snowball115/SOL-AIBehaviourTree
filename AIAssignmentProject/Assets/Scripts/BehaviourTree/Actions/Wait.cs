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

    public override IEnumerator Evaluate()
    {
        yield return new WaitForSeconds(seconds);

        SetState(NodeState.SUCCESS);
    }
}
