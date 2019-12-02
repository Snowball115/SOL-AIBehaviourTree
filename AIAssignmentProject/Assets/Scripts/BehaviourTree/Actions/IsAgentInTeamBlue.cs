using System.Collections;
using UnityEngine;

// Check if Agent is in blue, otherwise he is in red team
public class IsAgentInTeamBlue : LeafNode
{
    private AgentData data;

    public IsAgentInTeamBlue(AgentData data)
    {
        this.data = data;
    }

    protected override IEnumerator Execute()
    {
        if (data.EnemyTeam != AgentData.Teams.RedTeam)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);
        yield return null;
    }
}
