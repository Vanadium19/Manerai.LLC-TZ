using Game.Common;
using UnityEngine;
using Zenject;

namespace Game.GameObjects.UI
{
    public class SlotFactoryInstaller : Installer<ItemSlot, Transform, SlotFactoryInstaller>
    {
        private readonly ItemSlot _prefab;
        private readonly Transform _container;

        public SlotFactoryInstaller(ItemSlot prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
        }

        public override void InstallBindings()
        {
            Container.BindFactory<ItemType, ItemSlot, ItemSlotFactory>()
                .FromComponentInNewPrefab(_prefab)
                .WithGameObjectName(nameof(ItemSlot))
                .UnderTransform(_container)
                .AsSingle();
        }
    }
}