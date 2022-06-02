using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    public int curMagazine;
    public int maxMagazine;
    public static int curAmmo;
    public int maxAmmo;
    public float atkRate;

    public static bool isReload;

    private void Awake()
    {
        curMagazine = maxMagazine;
        curAmmo = maxAmmo;
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
