using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class BattleHud : MonoBehaviour
    {
        [SerializeField] private PartySystem party;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Canvas parent;

        private List<GameObject> hudList;
    
        public void OnEnable()
        {
            hudList = new List<GameObject>();
        
            CreateHudObjects();
            UpdateHealthBars();
        }

        private void CreateHudObjects()
        {
            for (var i = 0; i < party.PlayerParty.Count; i++)
            {
                var hudObject = Instantiate(prefab, parent.transform);
                SetHudPosition(hudObject, i);
                SetName(hudObject, i);
                hudList.Add(hudObject);
            }
        }

        private void SetName(GameObject hudObject, int i)
        {
            hudObject.GetComponentInChildren<TextMeshProUGUI>().text = party.PlayerParty[i].Name;
        }

        private static void SetHudPosition(GameObject hudObject, int i)
        {
            var height = hudObject.GetComponent<RectTransform>().rect.height;
            hudObject.transform.position -= new Vector3(0f, (height + 20) * i, 0f);
        }

        public void UpdateHealthBars()
        {
            for (var i = 0; i < party.PlayerParty.Count; i++)
            {
                var bar = hudList[i].transform.GetChild(2);
                var health = party.PlayerParty[i].Stats.Health;
                var maxHealth = party.PlayerParty[i].Stats.MaxHealth; 
                bar.transform.localScale = new Vector3((float)health/maxHealth, 1, 1);
            }
        }
    }
}
