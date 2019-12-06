using System.Collections;
using UnityEngine;

// ********************
// Check for enemy flag carrier
// ********************
public class GetEnemyFlagCarrier : LeafNode
{
    private AI agent;
    private Blackboard bbData;
    private GameObject enemyFlagCarrier;

    public GetEnemyFlagCarrier(AI agent, Blackboard bbData)
    {
        this.agent = agent;
        this.bbData = bbData;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        if (PlayerCache.GetEnemyFlagCarrier(agent) == null)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        enemyFlagCarrier = PlayerCache.GetEnemyFlagCarrier(agent);

        bbData.ModifyData("EnemyFlagCarrier", enemyFlagCarrier);

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}
