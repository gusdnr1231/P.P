using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GMControl : MonoBehaviour
{
    
    [SerializeField]
    private Text bulletUI;
    [SerializeField]
    private Text magazineUI;
    public static GMControl Instance = null;


    void Awake()
    {
        if (Instance == null) Instance = this;
    }


    void Update()
    {
        bulletUI.text = $"{Reload.curAmmo}/{Reload.maxAmmo}"; //(현재 총알 개수/최대 총알 개수)
        magazineUI.text = $"보유 탄창: {Reload.curMagazine}";
    }
}
