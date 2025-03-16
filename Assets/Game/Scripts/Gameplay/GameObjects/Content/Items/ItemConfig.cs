using Game.Common;
using UnityEngine;

namespace Game.GameObjects.Content.Items
{
    [CreateAssetMenu(fileName = "Item",
        menuName = "Items/New Item")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _id;
        [SerializeField] private float _weight;
        [SerializeField] private ItemType _type;
        [SerializeField] private Sprite _icon;

        public string ItemName => _itemName;
        public int Id => _id;
        public float Weight => _weight;
        public ItemType Type => _type;
        public Sprite Icon => _icon;
    }
}