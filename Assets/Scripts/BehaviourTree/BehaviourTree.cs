using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    private BaseNode root;

    public BehaviourTree(BaseNode rootNode)
    {
        root = rootNode;
    }

    public void Traverse()
    {
        root.Evaluate();
    }
}
