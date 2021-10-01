using System.Linq;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;
   
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;
    
    private RaycastHit[] _hits;
    private Plane _groundPlane;
    private Camera _camera;
    private Ray _ray;

    void Start()
    {
        _camera = Camera.main;
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }

        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        
        //_selectedObject.SetValue(null);
        
        var _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            _hits = Physics.RaycastAll(_ray);
            if (_hits.Length == 0)
            {
                return;
            }

            var selectable = _hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .Where(c=> c!=null)
                .FirstOrDefault();

            _selectedObject.SetValue(selectable);
        }
        else
        {
            if (_groundPlane.Raycast(_ray, out var enter))
            {
                _groundClicksRMB.SetValue(_ray.origin + _ray.direction * enter);
            }
        }
    }
}