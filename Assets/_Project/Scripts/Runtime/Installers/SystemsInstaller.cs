using _Project.Scripts.Runtime.Systems;
using UnityEngine;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    [SerializeField] private AmmoSpawnSystem _ammoSpawnSystem;
    [SerializeField] private PlayerGameJoinHandler _playerGameJoinHandler;
    [SerializeField] private GivePlayerItemSystem _givePlayerItemSystem;
    [SerializeField] private RoundSystem _roundSystem;
    [SerializeField] private SinglePlayerAISimulator _singlePlayerAISimulator;
    
    public override void InstallBindings()
    {
        Container.Bind<AmmoSpawnSystem>().FromInstance(_ammoSpawnSystem).AsSingle().NonLazy();
        Container.Bind<PlayerGameJoinHandler>().FromInstance(_playerGameJoinHandler).AsSingle().NonLazy();
        Container.Bind<GivePlayerItemSystem>().FromInstance(_givePlayerItemSystem).AsSingle().NonLazy();
        Container.Bind<RoundSystem>().FromInstance(_roundSystem).AsSingle().NonLazy();
        Container.Bind<SinglePlayerAISimulator>().FromInstance(_singlePlayerAISimulator).AsSingle().NonLazy();
    }
}