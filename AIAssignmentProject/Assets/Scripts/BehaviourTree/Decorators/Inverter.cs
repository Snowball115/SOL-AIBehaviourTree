using System.Collections;

// Inverts node
public class Inverter : Decorator
{
    public Inverter(BaseNode childNode)
    {
        this.childNode = childNode;
    }

    protected override IEnumerator Execute()
    {
        if (childNode.GetState() == NodeState.FAILURE) 
            childNode.SetState(NodeState.SUCCESS);

        else childNode.SetState(NodeState.FAILURE);

        yield return null;
    }
}
