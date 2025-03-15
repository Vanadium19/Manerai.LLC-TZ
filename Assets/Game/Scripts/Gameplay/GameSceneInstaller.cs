using Game.GameObjects.Content.Handle;
using Game.GameObjects.UI;
using Game.Scripts.Gameplay.GameSystems;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _handle;

        [SerializeField] private ItemSlot _itemSlotPrefab;
        [SerializeField] private Transform _slotsContainer;

        public override void InstallBindings()
        {
            HandleInstaller.Install(Container, _handle);
            GameSystemsInstaller.Install(Container);
            SlotFactoryInstaller.Install(Container, _itemSlotPrefab, _slotsContainer);
        }
    }
}