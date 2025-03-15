using System;
using Game.Common;
using Game.Scripts.Gameplay.GameSystems;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.GameObjects.UI
{
    public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private readonly Subject<ItemType> _currentItem = new();

        private ItemType _itemType;

        public Observable<ItemType> CurrentItem => _currentItem;

        private void OnEnable()
        {
            _currentItem.OnNext(ItemType.None);
        }

        private void OnDisable()
        {
            _currentItem.OnNext(ItemType.None);
        }

        [Inject]
        public void Construct(ItemType itemType)
        {
            _itemType = itemType;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _currentItem.OnNext(_itemType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _currentItem.OnNext(ItemType.None);
        }
    }
}