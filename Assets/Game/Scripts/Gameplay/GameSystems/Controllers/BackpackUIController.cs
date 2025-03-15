using Game.GameObjects.Content.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BackpackUIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private IBackpack _backpack;

        [Inject]
        public void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");

            _backpack.Open();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");

            _backpack.Close();
        }
    }
}