using Interfaces;
using UnityEngine;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "StrategyInstaller", menuName = "Installers/StrategyInstaller")]
public class StrategyInstaller : ScriptableObjectInstaller<StrategyInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _selectables);
        Container.Bind<IAwaitable<IAttackable>>()
            .FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>()
            .FromInstance(_groundClicksRMB);
    }
}