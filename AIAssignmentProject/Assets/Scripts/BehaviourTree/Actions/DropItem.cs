﻿using System.Collections;
using UnityEngine;

// ********************
// Drop an item on agents position
// ********************
public class DropItem : LeafNode
{
    private AgentActions actions;
    private GameObject itemToDrop;

    public DropItem(AgentActions actions, GameObject itemToDrop)
    {
        this.actions = actions;
        this.itemToDrop = itemToDrop;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        // This method already checks if item is in agents inventory
        actions.DropItem(itemToDrop);

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}