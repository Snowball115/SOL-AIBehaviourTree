using System.Collections;

public abstract class BaseNode
{
    private IEnumerator nodeCode;

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

    public IEnumerator Evaluate()
    {
        IEnumerator ie = Execute();
        yield return ie;
    }
}