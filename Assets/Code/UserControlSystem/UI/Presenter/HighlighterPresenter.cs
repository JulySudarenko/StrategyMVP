using System;
using Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

public class HighlighterPresenter : MonoBehaviour
{
    [Inject] private IObservable<ISelectable> _selectableValue;

    private IHighlightable[] _highlighters;
    private ISelectable _selectedActual;

    private void Start()
    {
        _selectableValue.Subscribe(OnSelected);
    }

    private void OnSelected(ISelectable selected)
    {
        if (_selectedActual == selected)
        {
            return;
        }

        _selectedActual = selected;

        if (_highlighters != null)
        {
            Highlight(_highlighters, false);
            _highlighters = null;
        }

        if (selected != null)
        {
            _highlighters = (selected as Component).GetComponentsInParent<IHighlightable>();
            Highlight(_highlighters, true);
        }
    }

    private void Highlight(IHighlightable[] highlightables, bool value)
    {
        for (int i = 0; i < highlightables.Length; i++)
        {
            highlightables[i].HighlightSelectedObject(value);
        }
    }
}
