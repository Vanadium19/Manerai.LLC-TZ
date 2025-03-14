using System;
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

        private Camera _camera;
        private float _depth;

        [Inject]
        public void Construct(IMousePosition mousePosition)
        {
            _mousePosition = mousePosition;
            _camera = Camera.main;
            _depth = transform.position.z - _camera.transform.position.z;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _disposable = _mousePosition.Value.Subscribe(SetItemPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _disposable?.Dispose();
        }

        private void SetItemPosition(Vector3 position)
        {
            var newPosition = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, _depth));

            transform.position = newPosition;
        }
    }
}