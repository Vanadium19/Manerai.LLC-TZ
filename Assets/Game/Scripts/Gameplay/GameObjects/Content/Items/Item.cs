using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public class Item : IItem
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly ItemConfig _config;

        public Item(Transform transform, Rigidbody rigidbody, ItemConfig config)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _config = config;
        }

        public void PickUp()
        {
            _rigidbody.isKinematic = true;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
        }
    }
}