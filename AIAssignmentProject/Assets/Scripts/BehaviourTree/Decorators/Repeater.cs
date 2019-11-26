using System.Collections;

public class Repeater : Decorator
{
    private CompositeNode node;

    public Repeater(CompositeNode node)
    {
        this.node = node;
    }

    protected override IEnumerator Execute()
    {
        if (node.GetState() == NodeState.SUCCESS | node.GetState() == NodeState.FAILURE) yield return node.Evaluate();

        yield return null;
    }
}
