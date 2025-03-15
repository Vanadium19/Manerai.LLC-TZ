using System.Collections.Generic;
using System.Linq;
using Game.Common;
using Game.GameObjects.Content.Handle;
using Game.GameObjects.Content.Items;
using R3;
using UnityEngine;

namespace Game.GameObjects.Content.Inventory
{
    public class Backpack : IBackpack
    {
        private readonly Dictionary<ItemType, Transform> _itemsPositions;
        private readonly Dictionary<ItemType, Stack<IItem>> _items;

        private readonly ReactiveProperty<bool> _openCommand = new();

        private ItemType _selectedItem;

        public Backpack(ItemBackpackParams[] backpackParams)
        {
            _itemsPositions = backpackParams.ToDictionary(item => item.ItemType, item => item.Transform);

            _items = new Dictionary<ItemType, Stack<IItem>>();

            foreach (var key in _itemsPositions.Keys)
                _items[key] = new Stack<IItem>();
        }

        public ReadOnlyReactiveProperty<bool> IsOpen => _openCommand;

        public void Open()
        {
            _openCommand.Value = true;
        }

        public void Close()
        {
            _openCommand.Value = false;
        }

        public void AddItem(IItem item)
        {
            item.Enable(false);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[item.ItemType].gameObject.SetActive(true);

            _items[item.ItemType].Push(item);
        }

        public bool TryGetItem(out IItem item)
        {
            item = null;

            if (_selectedItem == ItemType.None)
                return false;

            if (_items[_selectedItem].Count == 0)
                return false;

            item = _items[_selectedItem].Pop();
            item.Enable(true);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[_selectedItem].gameObject.SetActive(false);

            return true;
        }

        public void SelectItem(ItemType itemType)
        {
            _selectedItem = itemType;
        }
    }
}