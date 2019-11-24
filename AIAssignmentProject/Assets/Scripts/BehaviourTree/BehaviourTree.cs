using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    // The node our tree starts with
    private BaseNode rootNode;

    // Nodes in our BehaviourTree
    private List<BaseNode> cachedNodes;

    // Our main task which evaluates all nodes
    private IEnumerator mainLoop;

    private void Awake()
    {
        cachedNodes = new List<BaseNode>();
    }

    public void StartTree()
    {
        mainLoop = Traverse();
        StartCoroutine(mainLoop);
    }

    public void StopTree()
    {
        StopCoroutine(mainLoop);
        mainLoop = null;
    }

    private IEnumerator Traverse()
    {
        yield return null;
    }

    //public BehaviourTree(BaseNode rootNode)
    //{
    //    this.rootNode = rootNode;
    //}

    //public void Traverse()
    //{
    //    rootNode.Evaluate();
    //}
}