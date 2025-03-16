using System.Linq;
using Game.Common;
using Game.GameObjects.Content.Items;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameObjects.UI
{
    public class BackpackView : MonoBehaviour
    {
        [SerializeField] private GameObject _backpackPanel;

        private ItemSlot[] _slots;

        public Observable<ItemType> SelectedItem { get; private set; }

        [Inject]
        public void Construct(ItemConfig[] types, ItemSlotFactory factory)
        {
            _slots = new ItemSlot[types.Length];

            for (int i = 0; i < types.Length; i++)
                _slots[i] = factory.Create(types[i].Type, types[i].Icon);

            SelectedItem = _slots.Select(slot => slot.CurrentItem).Merge();
        }

        public void OpenBackpack(bool value)
        {
            _backpackPanel.SetActive(value);
        }

        public void EnableSlot(ItemType type, bool value)
        {
            foreach (ItemSlot slot in _slots)
            {
                if (slot.SlotType == type)
                {
                    slot.gameObject.SetActive(value);
                }
            }
        }
    }
}