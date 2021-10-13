using System;

public abstract class AwaitedBase<TAwaited> : IAwaiter<TAwaited>
{
    private TAwaited _result;
    private Action _continuation;
    private bool _isCompleted;

    public void OnCompleted(Action continuation)
    {
        if (_isCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            _continuation = continuation;
        }
    }

    public bool IsCompleted => _isCompleted;

    public TAwaited GetResult()
    {
        return _result;
    }

    protected void WaitingForResult(TAwaited obj)
    {
        _result = obj;
        _isCompleted = true;
        _continuation?.Invoke();
    }
}
