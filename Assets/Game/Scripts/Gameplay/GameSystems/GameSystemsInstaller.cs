using Game.GameSystems.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    public class GameSystemsInstaller : Installer<GameSystemsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SelectableSystem>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<DragAndDropController>()
                .AsSingle()
                .WithArguments(Camera.main)
                .NonLazy();
        }
    }
}