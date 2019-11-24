using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyInSight : LeafNode
{
    private Sensing senses;

    public IsEnemyInSight(Sensing senses)
    {
        this.senses = senses;
    }

    public override IEnumerator Evaluate()
    {
        List<GameObject> nearbyEnemies = senses.GetEnemiesInView();

        //for (int i = 0; i < nearbyEnemies.Count; i++) Debug.Log(nearbyEnemies.Count);

        if (nearbyEnemies.Count <= 0)
        {
            SetState(NodeState.FAILURE);
        }

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}