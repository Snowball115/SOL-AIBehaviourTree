using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : LeafNode
{
    private AgentActions actions;
    private Sensing senses;
    private GameObject itemToCollect;

    public CollectItem(AgentActions actions, Sensing senses, GameObject itemToCollect)
    {
        this.actions = actions;
        this.senses = senses;
        this.itemToCollect = itemToCollect;
    }

    protected override IEnumerator Execute()
    {
        if (!senses.IsItemInReach(itemToCollect))
        {
            SetState(NodeState.FAILURE);
        }

        // this method ALSO checks if item is in reach
        actions.CollectItem(itemToCollect);

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}