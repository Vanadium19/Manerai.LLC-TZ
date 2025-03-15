using System;
using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public class Item : IItem
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly ItemConfig _config;

        private bool _isFalling;

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
            _rigidbody.isKinematic = true;
        }

        // public void SetPositionForced(Vector3 position)
        // {
        //     _transform.position = position;
        // }

        public void Drop()
        {
            _isFalling = true;
            _transform.SetParent(null);
            _rigidbody.isKinematic = false;
            Dropped?.Invoke(this);
        }
    }
}