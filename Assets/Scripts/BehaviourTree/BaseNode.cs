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

    // Leaf nodes for e.g. Sequences or Selectors
    private List<BaseNode> leafNodes;

    public BaseNode()
    {

    }

    public abstract void Evaluate();
}
