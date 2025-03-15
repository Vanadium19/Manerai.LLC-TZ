using Game.Common;
using Game.GameObjects.Content.Handle;
using Game.GameObjects.Content.Items;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    public class SelectableSystem : ISelectableSystem
    {
        private readonly IHandle _handle;

        private IItem _currentItem;

        public SelectableSystem(IHandle handle)
        {
            _handle = handle;
        }

        public void SelectItem(IItem item)
        {
            if (_currentItem != null)
            {
                item.Drop();
                return;
            }

            _currentItem = item;
            _currentItem.PickUp(_handle.Point);
            // _currentItem.SetPosition(_handle.Point.position, () => _currentItem.PickUp(_handle.Point));
        }

        public void DeselectItem()
        {
            if (_currentItem == null)
                return;

            _currentItem.Drop();
            _currentItem = null;
        }
    }
}