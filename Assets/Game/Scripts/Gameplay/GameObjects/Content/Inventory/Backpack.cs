using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Common;
using Game.GameObjects.Content.Items;
using Game.Scripts.App;
using R3;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameObjects.Content.Inventory
{
    public class Backpack : IBackpack
    {
        private const string ItemStatusPut = "Put";
        private const string ItemStatusGet = "Get";

        private readonly Dictionary<ItemType, Transform> _itemsPositions;
        private readonly Dictionary<ItemType, Stack<IItem>> _items;

        private readonly ReactiveProperty<bool> _openCommand = new();

        private ItemType _selectedItem;

        public event UnityAction<int, string> ItemGot;
        public event UnityAction<int, string> ItemPut;

        public Backpack(ItemBackpackParams[] backpackParams)
        {
            _itemsPositions = backpackParams.ToDictionary(item => item.ItemType, item => item.Transform);

            _items = new Dictionary<ItemType, Stack<IItem>>();

            foreach (var key in _itemsPositions.Keys)
                _items[key] = new Stack<IItem>();
        }

        public ReadOnlyReactiveProperty<bool> IsOpen => _openCommand;

        public void Open(bool value)
        {
            _openCommand.Value = value;
        }

        public void SelectItem(ItemType itemType)
        {
            _selectedItem = itemType;
        }

        public void AddItem(IItem item)
        {
            item.SetPosition(_itemsPositions[item.ItemType].position, () => Put(item));
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
            ItemGot?.Invoke(item.Id, ItemStatusGet);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[_selectedItem].gameObject.SetActive(false);

            return true;
        }

        private void Put(IItem item)
        {
            if (_items[item.ItemType].Contains(item))
                return;

            item.Enable(false);

            if (_items[item.ItemType].Count == 0)
                _itemsPositions[item.ItemType].gameObject.SetActive(true);

            _items[item.ItemType].Push(item);
            ItemPut?.Invoke(item.Id, ItemStatusPut);
        }
    }
}