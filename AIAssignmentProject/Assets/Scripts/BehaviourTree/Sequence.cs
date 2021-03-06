﻿using System.Collections;
using UnityEngine;

// ******************
// Sequence: Iterates through nodes until one fails
// ******************
public class Sequence : CompositeNode
{
    // need this to loop the first sequence in tree, so the AI repeats the whole tree
    private bool IsIgnoringStates;

    public Sequence() { }

    public Sequence(bool IsIgnoringStates) 
    {
        this.IsIgnoringStates = IsIgnoringStates;
    }

    protected override IEnumerator Execute()
    {
        SetState(NodeState.RUNNING);

        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].SetState(NodeState.RUNNING);

            // Evaluate node while its running
            while (childNodes[i].GetState() == NodeState.RUNNING)
            {
                //// Check if node fails and exit while loop
                //if (childNodes[i].GetState() == NodeState.FAILURE)
                //{
                //    SetState(NodeState.FAILURE);
                //    Debug.Log("SEQUENCE INNER FAIL");
                //    yield break;
                //}

                // Evaluate the current node
                yield return childNodes[i].Evaluate();
            }

            // Exit condition
            if (childNodes[i].GetState() == NodeState.FAILURE && !IsIgnoringStates) 
            {
                //Debug.Log("SEQUENCE FAILED");
                SetState(NodeState.FAILURE);
                yield break;
            }
        }
        
        SetState(NodeState.SUCCESS);

        yield return null;
    }
}