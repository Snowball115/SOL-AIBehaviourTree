using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    private BaseNode root;

    public BehaviourTree(BaseNode rootNode)
    {
        root = rootNode;

        // Build and connect nodes here

    }

    public void Traverse()
    {
        root.Evaluate();
    }
}
