using Game.Common;
using Game.GameObjects.Content.Items;

namespace Game.GameObjects.Content.Inventory
{
    public interface IBackpack
    {
        public void AddItem(IItem item);
        public void RemoveItem(ItemType itemType);
    }
}