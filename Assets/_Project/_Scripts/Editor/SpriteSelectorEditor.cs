using PixelMoon.Control;
using UnityEditor;
using UnityEngine;

namespace PixelMoon._Project._Scripts.Editor
{
    [CustomEditor(typeof(SpriteSelector))]
    public class SpriteSelectorEditor : UnityEditor.Editor
    {
        private bool _initialized = false;

        SerializedProperty nameIndexProperty;

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();

            // Get the base class and refresh any changes
            SpriteSelector selector = (SpriteSelector)target;
            CallInitialRefresh(selector);
               
            //Labels
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Select Sprite from Dropdown", EditorStyles.boldLabel);

            //Display Sprite
            Sprite sprite = selector.GetSprite();
            float width = sprite.rect.width * 3;
            float height = sprite.rect.height * 3;
            float position = EditorGUIUtility.currentViewWidth / 2 - 25;
            GUI.DrawTextureWithTexCoords(new Rect(position, 85, width, height), selector.GetSprite().texture, GetSpriteRect(sprite));

            //Updates if dropBox returns a different int  
            int tempIndex = EditorGUILayout.Popup(selector.NameIndex, selector.fileNames, EditorStyles.toolbarDropDown);

            GUILayout.Space(180);

            //get serialised object
            var so = new SerializedObject(selector);
            so.FindProperty("nameIndex").intValue = tempIndex;
            so.ApplyModifiedProperties();
            selector.SetSprite();

            //Refresh the list of files
            if (GUILayout.Button("Refresh List"))
            {
                selector.RefreshList();
            }
        }

        private void CallInitialRefresh(SpriteSelector selector)
        {
            if (!_initialized)
            {
                selector.RefreshList();
            }
        }

        private Rect GetSpriteRect(Sprite sprite)
        {
            Rect rect = sprite.rect; 
            var tex = sprite.texture;

            rect.xMin /= tex.width;
            rect.xMax /= tex.width;
            rect.yMin /= tex.height;
            rect.yMax /= tex.height;
        
            return rect;
        }

    }
}
