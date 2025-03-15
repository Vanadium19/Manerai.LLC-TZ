using System;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Handle
{
    public class Handle : IInitializable, IDisposable, IHandle
    {
        private readonly Transform _transform;
        private readonly Camera _camera;
        private readonly float _depth;

        private IDisposable _disposable;

        public Handle(Transform transform, Camera camera)
        {
            _transform = transform;
            _camera = camera;

            _depth = _transform.position.z - _camera.transform.position.z;
        }

        public Transform Point => _transform;

        public void Initialize()
        {
            _disposable = Observable.EveryUpdate()
                .Select(_ => Input.mousePosition)
                .Subscribe(SetPosition);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void SetPosition(Vector3 position)
        {
            Vector3 newPosition = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, _depth));

            _transform.position = newPosition;
        }
    }
}