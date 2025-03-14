using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Items
{
    public class ItemInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.BindInterfacesTo<Item>()
                .AsSingle()
                .NonLazy();
        }
    }
}