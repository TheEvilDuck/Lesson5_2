using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayMediatorInstaller : MonoInstaller
{
    [SerializeField]private GameplayMediator _gameplayMediator;
    public override void InstallBindings()
    {
        Container.Bind<GameplayMediator>().FromInstance(_gameplayMediator);
    }
}
