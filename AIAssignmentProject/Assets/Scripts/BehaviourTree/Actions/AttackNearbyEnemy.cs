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

    protected override IEnumerator Execute()
    {
        List<GameObject> nearbyEnemies = senses.GetEnemiesInView();

        //for (int i = 0; i < nearbyEnemies.Count; i++) Debug.Log(nearbyEnemies.Count);

        if (nearbyEnemies.Count <= 0)
        {
            SetState(NodeState.FAILURE);
        }

        for (int i = 0; i < nearbyEnemies.Count; i++)
        {
            if (senses.IsInAttackRange(nearbyEnemies[i]))
            {
                actions.AttackEnemy(nearbyEnemies[i]);
            }
        }

        SetState(NodeState.SUCCESS);
        
        yield return null;
    }
}