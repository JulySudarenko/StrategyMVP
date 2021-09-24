using System.Linq;
using Interfaces;
using UnityEngine;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    
    private RaycastHit[] _hits;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        _hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (_hits.Length == 0)
        {
            return;
        }

        var selectable = _hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);

        _selectedObject.SetValue(selectable);
    }
}


