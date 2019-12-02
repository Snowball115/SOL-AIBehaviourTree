using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores visible enemies in a list and attacks its nearby enemy
public class AttackNearbyEnemy : LeafNode
{
    private AgentActions actions;
    private Sensing senses;
    private List<GameObject> nearbyEnemies;
    private WaitForSeconds attackTimer;

    public AttackNearbyEnemy(AgentActions actions, Sensing senses, float attackDelay)
    {
        this.actions = actions;
        this.senses = senses;

        attackTimer = new WaitForSeconds(attackDelay);
    }

    protected override IEnumerator Execute()
    {
        nearbyEnemies = senses.GetEnemiesInView();

        // If no enemy visible exit node
        if (nearbyEnemies.Count <= 0)
        {
            Debug.Log("FAIL");
            SetState(NodeState.FAILURE);
            yield break;
        }

        // Delay before agent can attack again
        yield return attackTimer;

        // Attack the nearby enemy
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