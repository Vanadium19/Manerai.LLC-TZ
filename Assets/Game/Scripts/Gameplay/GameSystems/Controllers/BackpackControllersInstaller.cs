using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BackpackControllersInstaller : MonoInstaller
    {
        [SerializeField] private BackpackCollisionController _backpackCollisionController;

        public override void InstallBindings()
        {
            Container.Bind<BackpackCollisionController>()
                .FromInstance(_backpackCollisionController)
                .AsSingle();
        }
    }
}