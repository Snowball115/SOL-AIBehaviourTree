using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode
{
    public enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    };

    protected NodeState currentState;

    public BaseNode() {}

    public NodeState GetState() => currentState;

    public void SetState(NodeState newState) => currentState = newState;

    public abstract void Evaluate();
}
