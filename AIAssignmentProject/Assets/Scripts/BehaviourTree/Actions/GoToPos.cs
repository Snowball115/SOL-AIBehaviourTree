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
        if (Vector3.Distance(agent.transform.position, newPos) <= 5)
        {
            Debug.Log("Success");
            return NodeState.SUCCESS;
        }

        Debug.Log("Running");
        actions.MoveTo(newPos);
        return NodeState.RUNNING;

        Debug.Log(GetState().ToString());
        return NodeState.FAILURE;
    }
}