using UnityEngine;

namespace PixelMoon.UI
{
    public class BattleMenu : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject menu;
        [SerializeField] private Vector3 offset;

        public void MoveToEntityPosition(Vector3 position)
        {
            if (!menu.activeSelf) 
                menu.SetActive(true);
        
            var screenPosition = cam.WorldToScreenPoint(position + offset);

            if (menu.transform.position != screenPosition)
            {
                menu.transform.position = screenPosition;
            }
        }

        public void HideMenu()
        {
            menu.SetActive(false);
        }

    }
}
