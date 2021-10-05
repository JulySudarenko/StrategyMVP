using System.Linq;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackedRBM;
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

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        _hits = Physics.RaycastAll(_ray);
        if (Input.GetMouseButtonUp(0))
        {
            if (WeHit<ISelectable>(_hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        }
        else
        {
            if (WeHit<IAttackable>(_hits, out var attackable))
            {
                _attackedRBM.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(_ray, out var enter))
            {
                _groundClicksRMB.SetValue(_ray.origin + _ray.direction * enter);
            }
        }
    }
    
    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }    
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .FirstOrDefault(c => c != null);
        return result != default;
    }
}
