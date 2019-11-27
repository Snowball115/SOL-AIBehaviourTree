using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.LogFormat("<b><color=green>[{0}]</color></b> Tree created", mb.gameObject.name);
        this.rootNode = rootNode;
        this.mb = mb;
    }

    public void Traverse()
    {
        Debug.LogFormat("<b><color=green>[{0}]</color></b> Tree started", mb.gameObject.name);
        mainLoop = rootNode.Evaluate();
        mb.StartCoroutine(mainLoop);
    }

    public void StopTree()
    {
        Debug.LogFormat("<b><color=green>[{0}]</color></b> Tree stopped", mb.gameObject.name);
        mb.StopCoroutine(mainLoop);
        mainLoop = null;
    }
}