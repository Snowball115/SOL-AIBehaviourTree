using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRandomPos : LeafNode
{
    private AgentActions actions;

    public GoToRandomPos(AgentActions actions)
    {
        this.actions = actions;
    }

    public override IEnumerator Evaluate()
    {
        actions.MoveToRandomLocation();

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}