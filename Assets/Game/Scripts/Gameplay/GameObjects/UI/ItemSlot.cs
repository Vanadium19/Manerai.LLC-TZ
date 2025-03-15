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
        private readonly ReactiveProperty<ItemType> _currentItem = new(ItemType.None);

        private ItemType _itemType;

        public ReadOnlyReactiveProperty<ItemType> CurrentItem => _currentItem;

        [Inject]
        public void Construct(ItemType itemType)
        {
            _itemType = itemType;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _currentItem.Value = _itemType;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _currentItem.Value = ItemType.None;
        }
    }
}