using System;
using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    public interface IItem
    {
        public event Action<IItem> Dropped;

        public bool IsFalling { get; }
        public ItemType ItemType { get; }

        public void Enable(bool value);
        public void PickUp(Transform parent);
        public void Drop();
    }
}