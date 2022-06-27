using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float spd;
    [SerializeField]
    private float dmg;
    [SerializeField]
    StageData stageData;
    Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

	void Update()
    {
        transform.Translate(Vector2.up * spd * Time.deltaTime);
        if (stageData.LimitMax.x + 2 < transform.position.x ||
            stageData.LimitMin.x - 2 > transform.position.x ||
            stageData.LimitMax.y + 2 < transform.position.y ||
            stageData.LimitMin.y - 2 > transform.position.y) Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(dmg);
            player.Score += 100;
            Destroy(gameObject);
        }
    }




}
