using Interfaces;
using UnityEngine;
using Zenject;

public class MainBuildingInstaller : MonoInstaller
{
    [SerializeField] private FactionMemberParallelInfoUpdater _factionMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container.Bind<ITickable>().FromInstance(_factionMemberParallelInfoUpdater);
        Container.Bind<IFactionMember>().FromComponentInChildren();
        // Container.Bind<IProduceChomperCommand>().FromComponentsInHierarchy().AsTransient();
        // Container.Bind<IProduceSpiderCommand>().FromComponentsInHierarchy().AsTransient();
        // Container.BindInterfacesAndSelfTo<ProduceChomperExecutor>().FromComponentsInHierarchy().AsTransient();
        // Container.BindInterfacesAndSelfTo<ProduceSpiderExecutor>().FromComponentsInHierarchy().AsTransient();
    }
}
