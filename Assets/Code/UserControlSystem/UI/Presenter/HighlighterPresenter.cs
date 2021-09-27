using Interfaces;
using UnityEngine;

public class HighlighterPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;

    private IHighlightable[] _highlighters;
    private ISelectable _selectedActual;

    private void Start()
    {
        _selectableValue.OnSelected += ONSelected;
        ONSelected(_selectableValue.CurrentValue);
    }

    private void ONSelected(ISelectable selected)
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
            var selectedComponent = selected as Component;
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