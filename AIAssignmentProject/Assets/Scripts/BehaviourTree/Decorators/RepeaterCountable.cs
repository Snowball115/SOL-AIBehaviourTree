using System.Collections;

public class RepeaterCountable : Decorator
{
    private int counter;
    private int repeatCount;

    public RepeaterCountable(BaseNode childNode, int repeatCount)
    {
        this.childNode = childNode;
        this.repeatCount = repeatCount;

        counter = 0;
    }

    protected override IEnumerator Execute()
    {
        while (counter <= repeatCount)
        {
            yield return childNode.Evaluate();
            counter++;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
