using System.Collections;

// ******************
// Evaluates node until it fails
// ******************
public class RepeatUntilNodeFails : Decorator
{
    public RepeatUntilNodeFails(BaseNode childNode)
    {
        this.childNode = childNode;
    }

    protected override IEnumerator Execute()
    {
        // Exit node if it fails
        if (childNode.GetState() == NodeState.FAILURE)
        {
            SetState(NodeState.SUCCESS);
            yield break;
        }

        childNode.SetState(NodeState.RUNNING);

        // Evaluate the child node
        while (childNode.GetState() == NodeState.RUNNING)
        {
            yield return childNode.Evaluate();
        }
    }
}