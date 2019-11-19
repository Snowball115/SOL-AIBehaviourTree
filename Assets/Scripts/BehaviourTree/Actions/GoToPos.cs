using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPos : Action
{
    private AI agent;
    private AgentActions actions;

    public GoToPos(AI agent, AgentActions actions)
    {
        this.agent = agent;
        this.actions = actions;
    }

    public override void Evaluate()
    {
        
    }
}
