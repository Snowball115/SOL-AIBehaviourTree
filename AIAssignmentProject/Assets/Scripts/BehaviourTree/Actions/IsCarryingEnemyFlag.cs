using System.Collections;

// ********************
// Checks if an agent is carrying the enemy flag
// ********************
public class IsCarryingEnemyFlag : LeafNode
{
    AgentData data;

    public IsCarryingEnemyFlag(AgentData data)
    {
        this.data = data;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        if (data.HasEnemyFlag)
        {
            SetState(NodeState.SUCCESS);
            yield break;
        }

        SetState(NodeState.FAILURE);

        yield return null;
    }
}
