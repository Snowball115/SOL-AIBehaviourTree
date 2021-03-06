﻿using System;
using System.Collections;
using UnityEngine;

// ******************
// Moves the agent to a specific position on the NavMesh
// ******************
public class GoToPos : LeafNode
{
    private AI agent;
    private AgentActions actions;
    private string blackboardEntry;
    private Blackboard bbData;
    private BaseNode attackAction;
    private GameObject target;

    // Tolerance to target position the agent has to reach, that he doesnt need to be exactly at the transforms position
    private float tolerance = 1;

    // Constructor to initialise target without specific blackboard data
    public GoToPos(AI agent, AgentActions actions, GameObject target)
    {
        this.agent = agent;
        this.actions = actions;
        this.target = target;
    }

    // Initialise target with a blackboard entry
    public GoToPos(AI agent, AgentActions actions, string blackboardEntry, Blackboard bbData)
    {
        this.agent = agent;
        this.actions = actions;
        this.blackboardEntry = blackboardEntry;
        this.bbData = bbData;
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
    public GoToPos(AI agent, AgentActions actions, GameObject target, float tolerance, BaseNode attackAction)
    {
        this.agent = agent;
        this.actions = actions;
        this.target = target;
        this.tolerance = tolerance;
        this.attackAction = attackAction;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        if (!String.IsNullOrEmpty(blackboardEntry))
            target = (GameObject)bbData.GetData(blackboardEntry);

        while(GetState() == NodeState.RUNNING)
        {
            actions.MoveTo(target);         

            if (Vector3.Distance(agent.transform.position, target.transform.position) > tolerance)
            {
                // Usually do attacking stuff here but it does not work
                if (attackAction != null) attackAction.Evaluate();
            }
            else
            {
                SetState(NodeState.SUCCESS);
                Debug.Log("Reached " + target.name);
                yield break;
            }

            yield return null;
        }

        yield return null;
    }
}