using Game.GameObjects.Content.Handle;
using Game.GameObjects.UI;
using Game.Scripts.Gameplay.GameSystems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Header("Handle")] [SerializeField] private Transform _handle;
        [SerializeField] private float _minPositionY = -0.55f;

        [Header("UI")] [SerializeField] private ItemSlot _itemSlotPrefab;
        [SerializeField] private Transform _slotsContainer;

        public override void InstallBindings()
        {
            //Content
            HandleInstaller.Install(Container, _handle, _minPositionY);

            //System
            GameSystemsInstaller.Install(Container);

            //UI
            SlotFactoryInstaller.Install(Container, _itemSlotPrefab, _slotsContainer);
        }
    }
}