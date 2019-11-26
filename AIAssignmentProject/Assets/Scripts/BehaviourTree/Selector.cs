using System.Collections;

public class Selector : CompositeNode
{
    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].SetState(NodeState.RUNNING);

            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                // Check if node successes and evaluate
                if (childNodes[i].GetState() == NodeState.SUCCESS)
                {
                    SetState(NodeState.SUCCESS);
                    yield return childNodes[i].Evaluate();
                }

                // Otherwise exit the selector
                yield break;
            }
        }

        yield return null;

        SetState(NodeState.FAILURE);
    }
}