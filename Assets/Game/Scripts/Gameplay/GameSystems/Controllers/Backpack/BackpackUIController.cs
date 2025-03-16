using Game.GameObjects.Content.Handle;
using Game.GameObjects.Content.Inventory;
using Game.GameObjects.Content.Items;
using Game.Scripts.Gameplay.GameSystems;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BackpackUIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private IHandle _handle;
        private IBackpack _backpack;
        private ISelectableSystem _selectableSystem;

        [Inject]
        public void Construct(IHandle handle, IBackpack backpack, ISelectableSystem selectableSystem)
        {
            _handle = handle;
            _backpack = backpack;
            _selectableSystem = selectableSystem;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _backpack.Open(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_backpack.TryGetItem(out IItem item))
                item.SetPosition(_handle.Point.position, () => _selectableSystem.SelectItem(item));

            _backpack.Open(false);
        }
    }
}