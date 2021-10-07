using UnityEngine;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "StrategyInstaller", menuName = "Installers/StrategyInstaller")]
public class StrategyInstaller : ScriptableObjectInstaller<StrategyInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackedValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectables);
    }
}