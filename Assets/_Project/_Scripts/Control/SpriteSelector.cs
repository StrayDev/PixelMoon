using System;
using System.IO;
using UnityEngine;

namespace PixelMoon.Control
{
    [Serializable]
    public class SpriteSelector : MonoBehaviour
    {
        private DirectoryInfo directory;
        private FileInfo[] files;
        public string[] fileNames;

        [SerializeField] private int nameIndex;

        public int NameIndex
        {
            get => nameIndex;
            set => nameIndex = value;
        }
    
        private void LateUpdate()
        {
            SetSprite();
        }

        public void RefreshList()
        {
            //load up the files
            directory = new DirectoryInfo("Assets/_Project/Resources/SpriteSheets/Entities/");
            files = directory.GetFiles("*.png");

            //create array and loop through
            fileNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension($"Assets/_Project/Resources/SpriteSheets/Entities/{files[i].Name}");
            }
        }

        public void SetSprite()
        {
            var subSprites = Resources.LoadAll<Sprite>("SpriteSheets/Entities/" + fileNames[nameIndex]);

            foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
            {
                string spriteName = renderer.sprite.name;
                var newSprite = Array.Find(subSprites, item => item.name == spriteName);

                if (newSprite)
                {
                    renderer.sprite = newSprite;
                }
            }
        }

        public Sprite GetSprite()
        {
            return GetComponent<SpriteRenderer>().sprite;
        }
    }
}
