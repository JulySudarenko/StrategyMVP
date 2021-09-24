using Interfaces;
using UnityEditor;
using UnityEngine;

public class HighlighterPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;

    //private IHighlightable[] _highlighters;
    private Highlighter[] _highlighters;
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
            //_highlighters = (selected as Component).GetComponent<IHighlightable[]>();
            //_highlighters = (selected as Component).GetComponentsInParent<Highlighter>();
            var highlighters = (selected as Component)?.GetComponentInParent<Highlighter>();
            //var f = highlighter.transform.GetComponents<Highlighter>();
            // for (int i = 0; i < _highlighters.Length; i++)
            // {
            //     _highlighters[i] 
            // }

            //Highlight(_highlighters, true);
        }
    }

    private void Highlight(Highlighter[] highlightables, bool value)
    {
        for (int i = 0; i < highlightables.Length; i++)
        {
            highlightables[i].ToString();
        }
    }
}
