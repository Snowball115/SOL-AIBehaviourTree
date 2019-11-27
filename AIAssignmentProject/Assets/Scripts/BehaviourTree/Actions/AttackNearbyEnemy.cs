using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores visible enemies in a list and attacks its nearby enemy
public class AttackNearbyEnemy : LeafNode
{
    private AgentActions actions;
    private Sensing senses;
    private List<GameObject> nearbyEnemies;

    public AttackNearbyEnemy(AgentActions actions, Sensing senses)
    {
        this.actions = actions;
        this.senses = senses;
    }

    protected override IEnumerator Execute()
    {
        nearbyEnemies = senses.GetEnemiesInView();

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