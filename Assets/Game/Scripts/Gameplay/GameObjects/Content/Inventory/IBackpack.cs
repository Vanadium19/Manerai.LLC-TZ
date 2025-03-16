using Game.Common;
using Game.GameObjects.Content.Items;
using R3;
using UnityEngine.Events;

namespace Game.GameObjects.Content.Inventory
{
    public interface IBackpack
    {
        public event UnityAction<int, string> ItemGot;
        public event UnityAction<int, string> ItemPut;

        public ReadOnlyReactiveProperty<bool> IsOpenObservable { get; }
        public Observable<(ItemType, bool)> ShowItemObservable { get; }

        public void Open(bool value);
        public void AddItem(IItem item);
        public bool TryGetItem(out IItem item);
        public void SelectItem(ItemType itemType);
    }
}