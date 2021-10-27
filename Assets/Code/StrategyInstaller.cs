using System;
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
    [SerializeField] private Sprite _chomperSprite;
    [SerializeField] private Sprite _spiderSprite;
    [SerializeField] private ChomperCommandsQueue _chomperPrefab;
    [SerializeField] private ChomperCommandsQueue _spiderPrefab;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groundClicksRMB);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectables);
        
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
        Container.Bind<ChomperCommandsQueue>().WithId("Chomper").FromInstance(_chomperPrefab);
        
        Container.Bind<Sprite>().WithId("Spider").FromInstance(_spiderSprite);
        Container.Bind<ChomperCommandsQueue>().WithId("Spider").FromInstance(_spiderPrefab);
    }
}
