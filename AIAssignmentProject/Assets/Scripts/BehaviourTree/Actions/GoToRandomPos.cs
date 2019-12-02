using System.Collections;

// Agent goes to a random position on NavMesh (just for testing purposes)
public class GoToRandomPos : LeafNode
{
    private AgentActions actions;

    public GoToRandomPos(AgentActions actions)
    {
        this.actions = actions;
    }

    protected override IEnumerator Execute()
    {
        actions.MoveToRandomLocation();

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}