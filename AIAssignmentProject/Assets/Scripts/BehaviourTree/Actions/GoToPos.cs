using System.Collections;
using UnityEngine;

// Moves the agent to a specific position on the NavMesh
public class GoToPos : LeafNode
{
    private AI agent;
    private AgentActions actions;
    private GameObject target;
    private BaseNode interruptableAction;

    // Tolerance to target position the agent has to reach, that he doesnt need to be exactly at the transforms position
    private float tolerance = 1;

    public GoToPos(AI agent, AgentActions actions, GameObject target)
    {
        this.agent = agent;
        this.actions = actions;
        this.target = target;
    }

    // Use this constructor to set own tolerance to reach if you have problems reaching a specific point on the NavMesh
    public GoToPos(AI agent, AgentActions actions, GameObject target, float tolerance)
    {
        this.agent = agent;
        this.actions = actions;
        this.target = target;
        this.tolerance = tolerance;
    }

    // Use this constructor to set own tolerance and an interruptable action
    public GoToPos(AI agent, AgentActions actions, GameObject target, float tolerance, BaseNode interruptableAction)
    {
        this.agent = agent;
        this.actions = actions;
        this.target = target;
        this.tolerance = tolerance;
        this.interruptableAction = interruptableAction;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        actions.MoveTo(target);

        //if (Vector3.Distance(agent.transform.position, newPos) <= tolerance) 
        //{
        //    SetState(NodeState.SUCCESS);
        //}

        while(GetState() == NodeState.RUNNING)
        {
            if (interruptableAction != null)
            {
                interruptableAction.Evaluate();
            }

            if (Vector3.Distance(agent.transform.position, target.transform.position) <= tolerance)
            {
                SetState(NodeState.SUCCESS);
                yield break;
            }

            yield return null;
        }

        yield return null;
    }
}