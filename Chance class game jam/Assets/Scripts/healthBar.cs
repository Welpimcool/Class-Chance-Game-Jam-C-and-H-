using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Slider hpSlider;

    public void setMaxHealth(int maxHp) {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }
    
    public void setHealth(int hp) {
        hpSlider.value = hp;
    }
}
