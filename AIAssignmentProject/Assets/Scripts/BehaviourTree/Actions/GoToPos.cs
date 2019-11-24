using System.Collections;
using UnityEngine;
public class GoToPos : LeafNode
{
    private AI agent;
    private AgentActions actions;
    private Vector3 newPos;

    public GoToPos(AI agent, AgentActions actions, Vector3 newPos)
    {
        this.agent = agent;
        this.actions = actions;
        this.newPos = newPos;
    }

    public override IEnumerator Evaluate()
    {
        actions.MoveTo(newPos);

        if (Vector3.Distance(agent.transform.position, newPos) <= 5) 
        {
            SetState(NodeState.SUCCESS); 
        }

        yield return null;
    }
}