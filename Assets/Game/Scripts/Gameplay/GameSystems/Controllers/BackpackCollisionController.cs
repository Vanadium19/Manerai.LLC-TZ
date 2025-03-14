using System;
using Game.GameObjects.Content.Inventory;
using Game.GameObjects.Content.Items;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BackpackCollisionController : MonoBehaviour
    {
        private IBackpack _backpack;

        [Inject]
        public void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out IItem item))
            {
                Debug.Log("Item entered backpack trigger");

                if (item.IsFalling)
                    _backpack.AddItem(item);
                else
                    item.Dropped += OnItemDropped;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out IItem item))
            {
                Debug.Log("Item exited backpack trigger");

                item.Dropped -= OnItemDropped;
            }
        }

        private void OnItemDropped(IItem item)
        {
            _backpack.AddItem(item);

            item.Dropped -= OnItemDropped;
        }
    }
}