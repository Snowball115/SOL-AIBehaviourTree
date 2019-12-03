using System.Collections;

public abstract class BaseNode
{
    // Node states for each node
    public enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    };

    protected NodeState currentState;

    public BaseNode() {}

    // Return the current state
    public NodeState GetState() => currentState;

    // Set the current state
    public void SetState(NodeState newState) => currentState = newState;

    // The code our node runs through
    protected abstract IEnumerator Execute();

    // This kinda resets the node if we want to evaluate it again because we assign it again
    // IEnumerator has a method called Reset() but it does not work
    public IEnumerator Evaluate()
    {
        IEnumerator ie = Execute();
        yield return ie;
    }
}