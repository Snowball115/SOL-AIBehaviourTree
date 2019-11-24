using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    // MonoBehaviour component for coroutine use in other nodes
    private MonoBehaviour mb { get; set; }

    // The node our tree starts with
    private BaseNode rootNode;

    public BehaviourTree(BaseNode rootNode, MonoBehaviour mb)
    {
        Debug.Log("<color=green>[BehaviourTree]</color> Tree created");

        this.rootNode = rootNode;

        this.mb = mb;
    }

    public void Traverse()
    {
        mb.StartCoroutine(rootNode.Evaluate());
    }
}