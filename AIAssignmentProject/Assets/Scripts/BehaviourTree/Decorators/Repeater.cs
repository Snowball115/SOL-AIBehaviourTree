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
        yield return node.Evaluate();
    }
}
