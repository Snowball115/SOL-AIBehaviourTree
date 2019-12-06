using System.Collections;

// ******************
// Inverts result of node
// ******************
public class Inverter : Decorator
{
    public Inverter(BaseNode childNode)
    {
        this.childNode = childNode;
    }

    protected override IEnumerator Execute()
    {
        //UnityEngine.Debug.LogFormat("Inverting {0}", childNode.GetType().Name);

        yield return childNode.Evaluate();

        if (childNode.GetState() == NodeState.FAILURE)
        {
            SetState(NodeState.SUCCESS);
        }

        else 
        {
            SetState(NodeState.FAILURE);
        } 

        yield return null;
    }
}
