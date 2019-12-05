using System.Collections;
using UnityEngine;

// ********************
// Check if an item is in reach and collect it
// ********************
public class CollectItem : LeafNode
{
    private AI agent;
    private AgentActions actions;
    private Sensing senses;
    private InventoryController inventory;
    private GameObject itemToCollect;

    public CollectItem(AI agent, AgentActions actions, Sensing senses, InventoryController inventory, GameObject itemToCollect)
    {
        this.agent = agent;
        this.actions = actions;
        this.senses = senses;
        this.inventory = inventory;
        this.itemToCollect = itemToCollect;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        // Fail action if item is out of reach
        if (!senses.IsItemInReach(itemToCollect))
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        actions.CollectItem(itemToCollect);

        // Check if agent acidentally thinks he picked up item but is not actually in his inventory
        if (!inventory.HasItem(itemToCollect.name.ToString()))
        {
            SetState(NodeState.FAILURE);
            yield break;
        }

        PlayerCache.SetFlagCarriers(itemToCollect);

        SetState(NodeState.SUCCESS);

        yield return null;
    }
}