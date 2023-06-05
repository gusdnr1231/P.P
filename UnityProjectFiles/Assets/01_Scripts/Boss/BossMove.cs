using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float r;
    private Quaternion dir;
    [SerializeField] StageData stageData;
    public float count = 0;

    void Start()
    {
        dir = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        r = Random.Range(5, 10);
        Debug.Log(r);
        StartCoroutine(cool());
    }

    void Update()
    {
    }

    IEnumerator Move()
	{
        if(count == 4)
            count = 1;
        else
            count++;
        switch (count)
		{
            case 1:
                transform.position = new Vector3(stageData.LimitMax.x, 0, 0);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
                break;
            case 2:
                transform.position = new Vector3(0, stageData.LimitMin.y, 0);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
                break ;
            case 3:
                transform.position = new Vector3(stageData.LimitMin.x, 0, 0);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
                break;
            case 4:
                transform.position = new Vector3(0, stageData.LimitMax.y, 0);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
                break;
		};
        yield return new WaitForSeconds(2f);
	}

    IEnumerator cool()
	{

		while (true)
		{
            yield return new WaitForSeconds(r);
            yield return StartCoroutine(Move());
            r = Random.Range(5, 10);
            Debug.Log(r);
		}

    }





}
