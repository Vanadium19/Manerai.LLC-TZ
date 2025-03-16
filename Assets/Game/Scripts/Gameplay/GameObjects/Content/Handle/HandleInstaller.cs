using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Handle
{
    public class HandleInstaller : Installer<Transform, float, HandleInstaller>
    {
        private readonly Transform _transform;
        private readonly float _minPositionY;

        public HandleInstaller(Transform transform, float minPositionY)
        {
            _transform = transform;
            _minPositionY = minPositionY;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Handle>()
                .AsSingle()
                .WithArguments(_transform, Camera.main, _minPositionY)
                .NonLazy();
        }
    }
}