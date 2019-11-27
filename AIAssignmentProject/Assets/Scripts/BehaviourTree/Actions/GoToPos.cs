using System.Collections;
using UnityEngine;

public class GoToPos : LeafNode
{
    private AI agent;
    private AgentActions actions;
    private Vector3 newPos;

    // Tolerance to target position the agent has to reach to return success
    private float tolerance = 1;

    public GoToPos(AI agent, AgentActions actions, Vector3 newPos)
    {
        this.agent = agent;
        this.actions = actions;
        this.newPos = newPos;
    }

    protected override IEnumerator Execute()
    {
        actions.MoveTo(newPos);

        if (Vector3.Distance(agent.transform.position, newPos) <= tolerance) 
        {
            SetState(NodeState.SUCCESS); 
        }

        yield return null;
    }
}