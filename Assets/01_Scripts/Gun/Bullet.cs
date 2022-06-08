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

    void Update()
    {
        transform.Translate(Vector2.right * spd * Time.deltaTime);
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
            Destroy(gameObject);
        }
    }




}
