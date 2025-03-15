using Game.Common;
using Game.GameObjects.Content.Items;

namespace Game.Scripts.Gameplay.GameSystems
{
    public interface ISelectableSystem
    {
        public bool HasItem { get; }

        public void SelectItem(IItem item);
        public void DeselectItem();
    }
}