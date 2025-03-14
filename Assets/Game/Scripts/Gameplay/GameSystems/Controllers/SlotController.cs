using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.GameSystems.Controllers
{
    public class SlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Pointer enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Pointer exit");
        }
    }
}