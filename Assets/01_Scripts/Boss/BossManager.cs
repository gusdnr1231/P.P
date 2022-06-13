using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFiring = 0, }


public class BossManager : MonoBehaviour
{
	[SerializeField] private GameObject bullet;
    BossMove bossMove;
	
	//패턴에 쓰이는 변수
	float attackRate = 0;
	int count = 0;
	float intervalAngle;
	float weightAngle;

	void Awake()
	{
		bossMove = GetComponent<BossMove>();	
	}

	public void StartFiring(AttackType attackType)
	{
		StartCoroutine(attackType.ToString());
	}

	public void StopFiring(AttackType attackType)
	{
		StopCoroutine(attackType.ToString());
	}

	private IEnumerator CircleFiring()
	{
		attackRate = 10f;
		count = 20;
		intervalAngle = 360/count;
		weightAngle = 0;

		while (true)
		{
			for (int i = 0; i < count; i++)
			{
				GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
				float angle = weightAngle + intervalAngle * i;
				float x = Mathf.Cos(angle * Mathf.PI / 180);
				float y = Mathf.Sin(angle * Mathf.PI / 180);
				clone.GetComponent<BulletMove>().MoveTo(new Vector3(x, y, 0));
			}
			weightAngle += 1;
			yield return new WaitForSeconds(attackRate);
		}


	}


}
