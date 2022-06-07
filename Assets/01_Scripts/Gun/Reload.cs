using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] private int ammo;
    [SerializeField] private int magazine;
    public static int curMagazine { get; set; }
    public static int maxMagazine { get; set; }
    public static int curAmmo { get; set; }
    public static int maxAmmo { get; set; }
    public static bool isReload;

    private void Awake()
    {
        maxAmmo = ammo;
        maxMagazine = magazine;
        curAmmo = maxAmmo;
        curMagazine = maxMagazine;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartReload();    
    }

    public void StartReload()
    {
        if (isReload == true || curMagazine <= 0) return;
        StartCoroutine("OnReload");
    }

    private IEnumerator OnReload()
    {
        isReload = true;
        while (true)
        {
            if ( audioSource.isPlaying == false)
            {
                isReload = false;
                curMagazine--;
                curAmmo = maxAmmo;
                yield break;
            }
            yield return null;
        }
    }
}
