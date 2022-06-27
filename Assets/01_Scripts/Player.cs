using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float spd;
    private Vector2 curPos;

    public static float x, y;
    SpriteRenderer spriteRenderer;

    int score;
    public int Score
	{
        set => score = Mathf.Max(0, value);
        get { return score; }
	}

    [SerializeField]private float maxHP;
    float curHP;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        curHP = maxHP;
    }

    void Update()
    {
        Move();
        Clamp();
    }

    private void Move() //이동
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 playerVec = new Vector3(x, y, 0);
        transform.position += playerVec * spd * Time.deltaTime;
    }

    private void Clamp() //이동 범위 제한
    {
        curPos = transform.position;
        curPos.x = Mathf.Clamp(curPos.x, -7.85f, 7.85f);
        curPos.y = Mathf.Clamp(curPos.y,-4.85f, 4.85f);
        transform.position = curPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossBullet"))
        {
            curHP--;
            Destroy(collision.gameObject);
            StopCoroutine("HitColorAnime");
			StartCoroutine("HitColorAnime");
			if(curHP == 0)
			{
                SceneManager.LoadScene("GameOver");
			}
        }
    }
    IEnumerator HitColorAnime()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }
}
