using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInView : LeafNode
{
    private AI agent;
    private Sensing senses;
    private GameObject itemToCheck;

    private List<GameObject> collectablesInView;

    public ItemInView(AI agent, Sensing senses, GameObject itemToCheck)
    {
        this.agent = agent;
        this.senses = senses;
    }

    protected override IEnumerator Execute()
    {
        collectablesInView = senses.GetCollectablesInView();

        for (int i = 0; i < collectablesInView.Count; i++)
        {
            if (collectablesInView[i] == itemToCheck)
            {
                Blackboard.AddData(string.Format("{0}", agent.name), itemToCheck);
                Blackboard.DebugDict();
                SetState(NodeState.SUCCESS);
                yield break;
            }
        }
        Debug.Log("NOT FOUND");
        SetState(NodeState.FAILURE);

        yield return null;
    }
}
