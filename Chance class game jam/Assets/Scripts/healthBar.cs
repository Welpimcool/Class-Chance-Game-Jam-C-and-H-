using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Slider hpSlider;
    public Image deathScreen;
    public Image deathScreen2;
    private float Timer = 0f;
    public float MaxTime = 3f;
    public void setMaxHealth(int maxHp) {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }
    
    public void setHealth(int hp) {
        hpSlider.value = hp;
    }
    public void start()
    {
        deathScreen.enabled = false;
        deathScreen2.enabled = false;
    }
    public void Update()
    {
        if (hpSlider.value <= 0)
        {
            deathScreen.enabled = true;
            if (Timer < MaxTime) {
                Timer += Time.deltaTime;
            } else {
                deathScreen2.enabled = true;
            }
        }
    }

}
