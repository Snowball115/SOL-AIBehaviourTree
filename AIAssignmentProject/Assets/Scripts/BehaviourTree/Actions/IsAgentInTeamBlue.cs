using System.Collections;
using UnityEngine;

// Check if Agent is in the blue team, otherwise he is in the red team
public class IsAgentInTeamBlue : LeafNode
{
    private AgentData data;

    public IsAgentInTeamBlue(AgentData data)
    {
        this.data = data;
    }

    protected override IEnumerator Execute()
    {
        // Checks if enemy team is equals to the red team
        if (data.EnemyTeam != AgentData.Teams.RedTeam)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);
        yield return null;
    }
}
