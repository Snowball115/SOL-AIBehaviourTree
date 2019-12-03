using System.Collections.Generic;

public abstract class CompositeNode : BaseNode
{
    // The nodes we will iterate
    protected List<BaseNode> childNodes;

    public CompositeNode()
    {
        childNodes = new List<BaseNode>();

        SetState(NodeState.RUNNING);
    }

    // Adds a node to its list
    public void AddNode(BaseNode node) => childNodes.Add(node);
}
