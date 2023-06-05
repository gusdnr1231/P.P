using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPGage : MonoBehaviour
{
    Slider sliderHP;
    BossHP bossHP;

    void Start()
    {
        bossHP = FindObjectOfType<BossHP>();
        sliderHP = GetComponent<Slider>();
    }

    
    void Update()
    {
        sliderHP.value = bossHP.CurHP / bossHP.MaxHP;
    }
}
