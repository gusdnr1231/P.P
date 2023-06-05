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
        bulletUI.text = $"{Reload.curAmmo}/{Reload.maxAmmo}"; //(���� �Ѿ� ����/�ִ� �Ѿ� ����)
        magazineUI.text = $"���� źâ: {Reload.curMagazine}";
    }
}
