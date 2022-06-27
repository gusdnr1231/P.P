using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    [SerializeField] private float maxHP;
    float curHP;

    public float MaxHP => maxHP;
    public float CurHP => curHP;

    SpriteRenderer spriteRenderer;
    

    void Awake()
    {
        curHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log("보스 명중");
        curHP = curHP-dmg;
        StopCoroutine("HitColorAnime");
        StartCoroutine("HitColorAnime");
        if (curHP <= 0)
        {
            Debug.Log("보스 사망");
            SceneManager.LoadScene("GameClear");
        }
    }

    IEnumerator HitColorAnime()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }



}
