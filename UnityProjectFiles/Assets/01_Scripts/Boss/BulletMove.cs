using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] Vector3 dir;
    [SerializeField] StageData stageData;

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (stageData.LimitMax.x + 2 < transform.position.x ||
            stageData.LimitMin.x - 2 > transform.position.x ||
            stageData.LimitMax.y + 2 < transform.position.y ||
            stageData.LimitMin.y - 2 > transform.position.y) Destroy(gameObject);
    }

    public void MoveTo(Vector3 direction)
	{
        dir = direction;
	}

}
