using System.Collections;

// Repeats a node
public class Repeater : Decorator
{
    public Repeater(BaseNode childNode)
    {
        this.childNode = childNode;
    }

    protected override IEnumerator Execute()
    {
        yield return childNode.Evaluate();
    }
}
