using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ****************
// Main Behaviour Tree class to start the traverse process
// ****************
public class BehaviourTree
{
    // MonoBehaviour component for coroutine use
    private MonoBehaviour mb { get; set; }

    // The node our tree starts with
    private BaseNode rootNode;

    // The main coroutine that enters the first node
    private IEnumerator mainLoop;

    public BehaviourTree(BaseNode rootNode, MonoBehaviour mb)
    {
        this.rootNode = rootNode;
        this.mb = mb;
    }

    // Start the tree
    public void Traverse()
    {
        Debug.LogFormat("<b><color=green>[{0}]</color></b> Tree started", mb.gameObject.name);
        mainLoop = rootNode.Evaluate();
        mb.StartCoroutine(mainLoop);
    }

    // Stop tree if necessary
    public void StopTree()
    {
        Debug.LogFormat("<b><color=green>[{0}]</color></b> Tree stopped", mb.gameObject.name);
        mb.StopCoroutine(mainLoop);
        mainLoop = null;
    }
}