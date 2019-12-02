using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Check if the agent sees any enemies
public class IsEnemyInSight : LeafNode
{
    private Sensing senses;
    private List<GameObject> nearbyEnemies;

    public IsEnemyInSight(Sensing senses)
    {
        this.senses = senses;
    }

    protected override IEnumerator Execute()
    {
        nearbyEnemies = senses.GetEnemiesInView();

        //for (int i = 0; i < nearbyEnemies.Count; i++) Debug.Log(nearbyEnemies.Count);

        if (nearbyEnemies.Count <= 0)
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}