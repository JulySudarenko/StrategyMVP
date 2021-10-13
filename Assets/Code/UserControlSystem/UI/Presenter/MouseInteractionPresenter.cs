using System.Linq;
using Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackClickRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;
    private Camera _camera;

    [Inject]
    private void Init()
    {
        _camera = Camera.main;
        _groundPlane = new Plane(_groundTransform.up, 0);

        var notBlockFrames = Observable.EveryUpdate()
            .Where(f => !_eventSystem.IsPointerOverGameObject());

        var leftClicks = notBlockFrames.Where(_ => Input.GetMouseButtonDown(0));
        var leftRays = leftClicks.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var leftHits = leftRays.Select(ray => Physics.RaycastAll(ray));
        leftHits.Subscribe(hits =>
        {
            if (WeHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });

        var rightClicks = notBlockFrames.Where(_ => Input.GetMouseButtonDown(1));
        var rightRays = rightClicks.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rightHits = rightRays.Select(ray => (ray, Physics.RaycastAll(ray)));

        rightHits.Subscribe((ray, hits) =>
        {
            if (WeHit<IAttackable>(hits, out var attackable))
            {
                _attackClickRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
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
