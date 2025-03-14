using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public interface IItem
    {
        public void PickUp();
        public void SetPosition(Vector3 position);
        public void Drop();
    }
}