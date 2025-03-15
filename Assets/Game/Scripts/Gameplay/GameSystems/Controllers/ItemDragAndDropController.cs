using System;
using Game.GameObjects.Content.Handle;
using Game.GameObjects.Content.Items;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class ItemDragAndDropController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private IHandle _handle;
        private IDisposable _disposable;
        private IItem _item;

        [Inject]
        public void Construct(IHandle handle, IItem item)
        {
            _item = item;
            _handle = handle;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _item.PickUp(_handle.Point);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _item.Drop();
        }
    }
}