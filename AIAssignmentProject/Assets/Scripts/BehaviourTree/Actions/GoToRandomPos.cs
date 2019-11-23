using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRandomPos : Action
{
    private AgentActions actions;

    public GoToRandomPos(AgentActions actions)
    {
        this.actions = actions;
    }

    public override NodeState Evaluate()
    {
        actions.MoveToRandomLocation();

        return NodeState.SUCCESS;
    }
}