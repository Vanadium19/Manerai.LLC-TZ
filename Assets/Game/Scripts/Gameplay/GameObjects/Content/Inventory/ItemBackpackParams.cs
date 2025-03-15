using System;
using Game.Common;
using Game.GameObjects.Content.Items;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameObjects.Content.Inventory
{
    [Serializable]
    public struct ItemBackpackParams
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private Transform _transform;

        public ItemConfig Config => _itemConfig;
        public Transform Transform => _transform;
    }
}