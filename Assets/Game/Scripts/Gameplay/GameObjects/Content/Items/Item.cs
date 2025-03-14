using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public class Item : IItem
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;

        public Item(Transform transform, Rigidbody rigidbody)
        {
            _transform = transform;
            _rigidbody = rigidbody;
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