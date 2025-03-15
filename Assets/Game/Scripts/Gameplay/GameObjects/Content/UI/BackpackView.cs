using UnityEngine;

namespace Game.GameObjects.Content.UI
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