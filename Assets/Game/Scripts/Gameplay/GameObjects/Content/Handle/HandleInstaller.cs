using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Handle
{
    public class HandleInstaller : Installer<Transform, HandleInstaller>
    {
        private readonly Transform _transform;

        public HandleInstaller(Transform transform)
        {
            _transform = transform;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Handle>()
                .AsSingle()
                .WithArguments(_transform, Camera.main)
                .NonLazy();
        }
    }
}