using System.Collections.Generic;
using System.Linq;
using Game.Common;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameObjects.UI
{
    public class BackpackView : MonoBehaviour
    {
        [SerializeField] private GameObject _backpackPanel;

        public Observable<ItemType> SelectedItem { get; private set; }

        [Inject]
        public void Construct(ItemType[] types, ItemSlotFactory factory)
        {
            ItemSlot[] slots = new ItemSlot[types.Length];

            for (int i = 0; i < types.Length; i++)
                slots[i] = factory.Create(types[i]);

            SelectedItem = slots.Select(slot => slot.CurrentItem).Merge();
        }

        public void OpenBackpack(bool value)
        {
            _backpackPanel.SetActive(value);
        }
    }
}