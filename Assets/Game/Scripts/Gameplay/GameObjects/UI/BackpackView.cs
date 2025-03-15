using UnityEngine;

namespace Game.GameObjects.UI
{
    public class BackpackView : MonoBehaviour
    {
        [SerializeField] private GameObject _backpackPanel;

        public void OpenBackpack(bool value)
        {
            _backpackPanel.SetActive(value);
        }
    }
}