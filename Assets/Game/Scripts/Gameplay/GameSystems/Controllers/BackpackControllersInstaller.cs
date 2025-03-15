using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BackpackControllersInstaller : MonoInstaller
    {
        [SerializeField] private BackpackCollisionController _backpackCollisionController;
        [SerializeField] private BackpackUIController _backpackUIController;

        public override void InstallBindings()
        {
            Container.Bind<BackpackCollisionController>()
                .FromInstance(_backpackCollisionController)
                .AsSingle();

            Container.Bind<BackpackUIController>()
                .FromInstance(_backpackUIController)
                .AsSingle();
        }
    }
}