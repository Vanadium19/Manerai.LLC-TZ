using Game.Common;
using R3;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Game.GameObjects.UI
{
    public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _image;

        private readonly Subject<ItemType> _currentItem = new();

        private ItemType _itemType;

        public ItemType SlotType => _itemType;
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
        public void Construct(ItemType itemType, Sprite icon)
        {
            _itemType = itemType;
            _image.sprite = icon;
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