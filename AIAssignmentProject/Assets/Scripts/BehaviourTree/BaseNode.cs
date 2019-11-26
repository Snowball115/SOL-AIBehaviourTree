using System.Collections;

public abstract class BaseNode
{
    public enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    };

    protected NodeState currentState;

    public BaseNode() {}

    public NodeState GetState() => currentState;

    public void SetState(NodeState newState) => currentState = newState;

    protected abstract IEnumerator Execute();

    // This kinda resets the node if we want to evaluate it again
    public IEnumerator Evaluate()
    {
        IEnumerator ie = Execute();
        yield return ie;
    }
}