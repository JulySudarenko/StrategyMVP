using System.Linq;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;
    
    private RaycastHit[] _hits;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        
        _selectedObject.SetValue(null);
        
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