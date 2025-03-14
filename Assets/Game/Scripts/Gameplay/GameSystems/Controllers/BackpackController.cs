using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.GameSystems.Controllers
{
    public class BackpackController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");
        }
    }
}