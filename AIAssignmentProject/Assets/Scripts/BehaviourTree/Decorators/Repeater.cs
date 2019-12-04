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
        UnityEngine.Debug.LogFormat("Repeating {0}", childNode.GetType());

        yield return childNode.Evaluate();
    }
}
