using System;
using UniRx;

public abstract class StatelessScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
{
    protected Subject<T> _innerDataSource = new Subject<T>();
    
    public virtual void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.OnNext(value);
    }
    
    public IDisposable Subscribe(IObserver<T> observer) => _innerDataSource.Subscribe(observer);
}
