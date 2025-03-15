using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public class Item : IItem
    {
        private const float MoveDuration = 0.2f;

        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly ItemConfig _config;

        private bool _isFalling;
        private Tween _moveTween;

        public event Action<IItem> Dropped;

        public Item(Transform transform, Rigidbody rigidbody, ItemConfig config)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _config = config;
        }

        public bool IsFalling => _isFalling;
        public ItemType ItemType => _config.Type;

        public void Enable(bool value)
        {
            _transform.gameObject.SetActive(value);
            _rigidbody.isKinematic = true;
            _isFalling = false;
        }

        public void PickUp(Transform parent)
        {
            _isFalling = false;
            _transform.SetParent(parent);
            _transform.localPosition = Vector3.zero;
            _rigidbody.isKinematic = true;
        }

        public void SetPosition(Vector3 position, Action callback = null)
        {
            _moveTween = _transform.DOMove(position, MoveDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => callback?.Invoke());
        }

        public void Drop()
        {
            _isFalling = true;
            _moveTween?.Kill();
            _transform.SetParent(null);
            _rigidbody.isKinematic = false;
            Dropped?.Invoke(this);
        }
    }
}