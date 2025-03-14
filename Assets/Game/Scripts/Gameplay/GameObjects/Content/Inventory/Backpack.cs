using System.Collections.Generic;
using System.Linq;
using Game.Common;
using Game.GameObjects.Content.Items;
using UnityEngine;

namespace Game.GameObjects.Content.Inventory
{
    public class Backpack : IBackpack
    {
        private readonly Dictionary<ItemType, Transform> _itemsPositions;
        private readonly Dictionary<ItemType, Stack<IItem>> _items;

        public Backpack(ItemBackpackParams[] backpackParams)
        {
            _itemsPositions = backpackParams.ToDictionary(item => item.ItemType, item => item.Transform);

            _items = new Dictionary<ItemType, Stack<IItem>>();

            foreach (var key in _itemsPositions.Keys)
                _items[key] = new Stack<IItem>();
        }

        public void AddItem(IItem item)
        {
            item.Enable(false);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[item.ItemType].gameObject.SetActive(true);

            _items[item.ItemType].Push(item);
        }

        public void RemoveItem(ItemType itemType)
        {
            if (_items[itemType].Count == 0)
                return;

            IItem item = _items[itemType].Pop();
            item.Enable(true);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[itemType].gameObject.SetActive(false);
        }
    }
}