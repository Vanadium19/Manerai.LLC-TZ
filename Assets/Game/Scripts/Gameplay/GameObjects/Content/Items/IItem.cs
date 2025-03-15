using System;
using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public interface IItem
    {
        public bool IsMoving { get; }
        public ItemType ItemType { get; }
        public int Id { get; }

        public void Enable(bool value);
        public void PickUp(Transform parent);
        public void SetPosition(Vector3 position, Action callback = null);
        public void Drop();
    }
}