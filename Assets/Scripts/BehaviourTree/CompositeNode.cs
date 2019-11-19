using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : BaseNode
{
    protected List<BaseNode> childNodes;

    public void AddNode(BaseNode node) => childNodes.Add(node);
}
