using System.Collections.Generic;

public abstract class CompositeNode : BaseNode
{
    protected List<BaseNode> childNodes;

    protected bool isAnyNodeEvaluating;

    public CompositeNode()
    {
        childNodes = new List<BaseNode>();
    }

    public void AddNode(BaseNode node) => childNodes.Add(node);
}
