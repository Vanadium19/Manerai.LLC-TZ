using System;
using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Inventory
{
    [Serializable]
    public struct ItemBackpackParams
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Transform _transform;

        public ItemType ItemType => _itemType;
        public Transform Transform => _transform;
    }
}