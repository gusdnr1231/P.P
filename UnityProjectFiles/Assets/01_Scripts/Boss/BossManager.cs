using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFiring = 0, LazerFiring, }


public class BossManager : MonoBehaviour
{
	[SerializeField] private GameObject bullet; //패턴 1 총알
	[SerializeField] private GameObject LazerRange; //패턴 2 레이저 범위
	[SerializeField] private GameObject Lazer; //패턴 2 레이저

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
		attackRate = 0.5f;
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

	private IEnumerator LazerFiring()
	{
		attackRate = 3f;
		count = 4;
		while (true)
		{
			for (int i = 0; i < count; i++)
			{
				float y = Random.Range(-4f, 2f);
				GameObject lr /* 레이저 범위 복사 */ = Instantiate(LazerRange, new Vector3(0, y, 0), Quaternion.identity);
				yield return new WaitForSeconds(0.4f);
				Destroy(lr);
				GameObject lzr = Instantiate(Lazer, new Vector3(0, y, 0), Quaternion.identity);
				Destroy(lzr, 0.5f);
			}
			yield return new WaitForSeconds(attackRate);
		}
	}



}
