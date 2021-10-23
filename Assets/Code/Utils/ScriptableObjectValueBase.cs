using System;
using UnityEngine;

public class  ScriptableObjectValueBase<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> :  AwaitedBase<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;

        public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += OnNewValue;
        }

        private void OnNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= OnNewValue;
            WaitingForResult(obj);
        }
    }

    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}