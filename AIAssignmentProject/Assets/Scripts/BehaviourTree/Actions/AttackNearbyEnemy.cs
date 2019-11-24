using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNearbyEnemy : LeafNode
{
    private Sensing senses;
    private AgentActions actions;

    public AttackNearbyEnemy(Sensing senses, AgentActions actions)
    {
        this.senses = senses;
        this.actions = actions;
    }

    public override IEnumerator Evaluate()
    {
        List<GameObject> nearbyEnemies = senses.GetEnemiesInView();

        //for (int i = 0; i < nearbyEnemies.Count; i++) Debug.Log(nearbyEnemies.Count);

        if (nearbyEnemies.Count <= 0)
        {
            SetState(NodeState.FAILURE);
            Debug.Log("FAIL");
        }

        for (int i = 0; i < nearbyEnemies.Count; i++)
        {
            if (senses.IsInAttackRange(nearbyEnemies[i]))
            {
                actions.AttackEnemy(nearbyEnemies[i]);
                Debug.Log("ATTACK");
            }
        }

        SetState(NodeState.SUCCESS);
        
        yield return null;
    }
}