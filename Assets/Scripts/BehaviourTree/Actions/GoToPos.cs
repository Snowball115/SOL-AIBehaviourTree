using UnityEngine;

public class GoToPos : Action
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

    public override NodeState Evaluate()
    {
        if (agent.transform.position != newPos)
        {
            actions.MoveTo(newPos);
            return NodeState.RUNNING;
        }

        else if (Vector3.Distance(agent.transform.position, newPos) <= 10) 
        {
            Debug.Log("Success");
            return NodeState.SUCCESS;
        }

        Debug.Log(currentState.ToString());
        return NodeState.FAILURE;
    }
}