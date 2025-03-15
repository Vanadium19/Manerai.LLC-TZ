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
        private IBackpack _backpack;
        private ISelectableSystem _selectableSystem;

        [Inject]
        public void Construct(IBackpack backpack, ISelectableSystem selectableSystem)
        {
            _backpack = backpack;
            _selectableSystem = selectableSystem;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _backpack.Open();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_backpack.TryGetItem(out IItem item))
                _selectableSystem.SelectItem(item);

            _backpack.Close();
        }
    }
}