using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ******************
// Base class for action nodes
// ******************
public abstract class LeafNode : BaseNode
{
    public LeafNode()
    {
        // Initialise action as soon as we create them
        SetState(NodeState.RUNNING);
    }


}
