using System.Collections;

public class RepeaterCountable : Decorator
{
    private CompositeNode node;
    private int counter;
    private int repeatCount;

    public RepeaterCountable(CompositeNode node, int repeatCount)
    {
        this.node = node;
        this.repeatCount = repeatCount;

        counter = 0;
    }

    protected override IEnumerator Execute()
    {
        while (counter <= repeatCount)
        {
            if (node.GetState() == NodeState.SUCCESS | node.GetState() == NodeState.FAILURE) yield return node.Evaluate();
            counter++;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
