using Game.GameObjects.Content.Handle;
using Game.GameObjects.Content.Items;

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

        public bool HasItem => _currentItem != null;
        public IItem CurrentItem => _currentItem;

        public void SelectItem(IItem item)
        {
            if (_currentItem != null)
            {
                item.Drop();
                return;
            }

            _currentItem = item;
            _currentItem.PickUp(_handle.Point);
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