using System;
using Game.GameObjects.Content.Items;
using Game.GameSystems.Inputs;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class ItemDragAndDropController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private IMousePosition _mousePosition;
        private IDisposable _disposable;
        private IItem _item;

        private Camera _camera;
        private float _depth;

        [Inject]
        public void Construct(IMousePosition mousePosition, IItem item, Transform itemTransform)
        {
            _item = item;
            _camera = Camera.main;
            _mousePosition = mousePosition;
            _depth = itemTransform.position.z - _camera.transform.position.z;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _item.PickUp();
            _disposable = _mousePosition.Value.Subscribe(SetItemPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _item.Drop();
            _disposable?.Dispose();
        }

        private void SetItemPosition(Vector3 position)
        {
            Vector3 newPosition = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, _depth));

            _item.SetPosition(newPosition);
        }
    }
}