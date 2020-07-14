using UnityEngine;

namespace PixelMoon.Utilities
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;

        private Quaternion originalRotation;

        private void Start()
        {
            originalRotation = transform.rotation;
        }

        private void Update()
        {
            transform.rotation = cameraTransform.rotation * originalRotation; 
        }
    }
}
