using Game.GameObjects.Content.Inventory;
using Game.GameObjects.Content.Items;
using Game.Modules.Entities;
using Game.Scripts.Gameplay.GameSystems;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class DragAndDropController : ITickable
    {
        private readonly ISelectableSystem _selectableSystem;
        private readonly Camera _camera;

        public DragAndDropController(ISelectableSystem selectableSystem, Camera camera)
        {
            _selectableSystem = selectableSystem;
            _camera = camera;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                SelectItem();

            if (Input.GetKeyUp(KeyCode.Mouse0))
                DeselectItem();
        }

        private void SelectItem()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IEntity entity) && entity.TryGet(out IItem item))
                {
                    _selectableSystem.SelectItem(item);
                }
            }
        }

        private void DeselectItem()
        {
            if (!_selectableSystem.HasItem)
                return;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IEntity entity) && entity.TryGet(out IBackpack backpack))
                {
                    backpack.AddItem(_selectableSystem.CurrentItem);
                }
            }

            _selectableSystem.DeselectItem();
        }
    }
}