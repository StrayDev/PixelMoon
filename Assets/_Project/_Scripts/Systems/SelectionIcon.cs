using UnityEngine;

namespace PixelMoon.Systems
{
    public class SelectionIcon : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;
        [SerializeField] private float positionOffset;
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            if (!renderer.enabled) return;
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        }

        public void SetPosition(Vector3 target)
        {
            target += new Vector3(0, positionOffset, 0);
            transform.position = target;
        }

        public void SetHidden(bool hide)
        {
            renderer.enabled = !hide;
        }
    }
}
