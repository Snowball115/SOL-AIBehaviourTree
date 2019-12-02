using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItemInView : LeafNode
{
    private Sensing senses;
    private GameObject itemToCheck;
    private List<GameObject> itemsInView;

    public IsItemInView(Sensing senses, GameObject itemToCheck)
    {
        this.senses = senses;
        this.itemToCheck = itemToCheck;
    }

    protected override IEnumerator Execute()
    {
        itemsInView = senses.GetObjectsInView();

        //for (int i = 0; i < itemsInView.Count; i++)
        //{
        //    Debug.Log(itemsInView[i].ToString());
        //}

        for (int i = 0; i < itemsInView.Count; i++)
        {
            if (itemsInView[i] == itemToCheck)
            {
                SetState(NodeState.SUCCESS);
                yield break;
            }
        }

        SetState(NodeState.FAILURE);
        
        yield return null;
    }
}
