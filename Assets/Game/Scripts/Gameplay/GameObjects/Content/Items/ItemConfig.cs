using Codice.Client.BaseCommands.Merge.Xml;
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

        public string ItemName => _itemName;
        public int Id => _id;
        public float Weight => _weight;
        public ItemType Type => _type;
    }
}