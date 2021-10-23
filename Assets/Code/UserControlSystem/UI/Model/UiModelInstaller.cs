using Interfaces;
using UnityEngine;
using Utils;
using Zenject;

public class UiModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _goundClicksRMB;
    [SerializeField] private AttackableValue _attackedRMB;
    [SerializeField] private SelectableValue _selectableValue;

    [SerializeField] private Sprite _chomperSprite;
    [SerializeField] private GameObject _chomperPrefab;
    [SerializeField] private Sprite _spiderSprite;
    [SerializeField] private GameObject _spiderPrefab;

    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<Vector3Value>().FromInstance(_goundClicksRMB);
        Container.Bind<AttackableValue>().FromInstance(_attackedRMB);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);

        Container.Bind<CommandCreatorBase<IProduceChomperCommand>>()
            .To<ProduceChomperCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IProduceSpiderCommand>>()
            .To<ProduceSpiderCommandCreator>().AsTransient();
        
        Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
            .To<SetRallyPointCommandCreator>().AsTransient();

        Container.Bind<float>().WithId("Chomper").FromInstance(5f);
        Container.Bind<string>().WithId("Chomper").FromInstance("Chomper");
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
        Container.Bind<GameObject>().WithId("Chomper").FromInstance(_chomperPrefab);

        Container.Bind<float>().WithId("Spider").FromInstance(10f);
        Container.Bind<string>().WithId("Spider").FromInstance("Spider");
        Container.Bind<Sprite>().WithId("Spider").FromInstance(_spiderSprite);
        Container.Bind<GameObject>().WithId("Spider").FromInstance(_spiderPrefab);
        
        Container.Bind<CommandButtonsModel>().AsTransient();
        Container.Bind<BottomCenterModel>().AsTransient();
    }
}
