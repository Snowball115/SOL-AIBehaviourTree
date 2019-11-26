using System.Collections;

public class Repeater : Decorator
{
    public Repeater(CompositeNode childNode)
    {
        this.childNode = childNode;
    }

    protected override IEnumerator Execute()
    {
        yield return childNode.Evaluate();
    }
}
