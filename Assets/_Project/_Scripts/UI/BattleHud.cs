using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelMoon.UI
{
    public class BattleHud : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI levelText;
        public Slider hpSlider;

        // public void SetHud(Stats status)
        //{
        //nameText.text = status.Name;
        //levelText.text = "Lvl " + unit.unitLevel;
        //hpSlider.maxValue = unit.maxHP;
        //hpSlider.value = unit.currentHP;
        // }

        public void SetHP(int hp)
        {
            hpSlider.value = hp;
        }
    }
}
