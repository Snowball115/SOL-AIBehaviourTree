using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode
{
    enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    };

    private NodeState currentState;

    public BaseNode() {}

    //public abstract void Evaluate();
}
