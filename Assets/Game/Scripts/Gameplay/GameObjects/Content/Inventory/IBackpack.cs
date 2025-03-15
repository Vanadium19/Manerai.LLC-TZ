using Game.Common;
using Game.GameObjects.Content.Items;
using R3;

namespace Game.GameObjects.Content.Inventory
{
    public interface IBackpack
    {
        public ReadOnlyReactiveProperty<bool> IsOpen { get; }

        public void Open();
        public void Close();
        public void AddItem(IItem item);
        public bool TryGetItem(out IItem item);
        public void SelectItem(ItemType itemType);
    }
}