using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Check if GameObject has the given tag
public class CheckTag : LeafNode
{
    private AI agent;
    private string tagToCheck;

    public CheckTag(AI agent, string tagToCheck)
    {
        this.agent = agent;
        this.tagToCheck = tagToCheck;
    }

    protected override IEnumerator Execute()
    {
        if (agent.tag == tagToCheck)
        {
            SetState(NodeState.SUCCESS);
            yield break;
        }

        SetState(NodeState.FAILURE);

        yield return null;
    }
}
