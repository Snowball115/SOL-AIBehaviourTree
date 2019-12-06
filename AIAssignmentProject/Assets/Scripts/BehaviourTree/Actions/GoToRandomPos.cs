using System.Collections;

// *******************
// Agent goes to random position on NavMesh
// *******************
public class GoToRandomPos : LeafNode
{
    private AgentActions actions;

    public GoToRandomPos(AgentActions actions)
    {
        this.actions = actions;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        actions.MoveToRandomLocation();

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}