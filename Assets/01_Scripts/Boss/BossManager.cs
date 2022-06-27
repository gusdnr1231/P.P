using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { BossStart = 0, CircleFiring, LazerFiring, SpawnEnemy, };

public class BossManager : MonoBehaviour
{
	[SerializeField] private GameObject bullet; //패턴 1 총알
	[SerializeField] private GameObject LazerRange; //패턴 2 레이저 범위
	[SerializeField] private GameObject Lazer; //패턴 2 레이저
	[SerializeField] private GameObject Enemy; //패턴 3 에너미
	
	private Movement movement;
	private float bossPoint = 5f;
	public float patternCount = 0;

	BossMove bossMove;

	//패턴에 쓰이는 변수
	float attackRate = 0;
	int count = 0;
	float intervalAngle;
	float weightAngle;
	bool isFire;
	float fireTime;
	private AttackType attackType = AttackType.BossStart;

	void Awake()
	{
		bossMove = GetComponent<BossMove>();
		movement = GetComponent<Movement>();
	}

	private void Start()
	{
		StartCoroutine("BossStart");
	}

	private IEnumerator BossStart()
	{
		movement.MoveTo(Vector3.down);
		while (true)
		{
			if (transform.position.y <= bossPoint)
			{
				movement.MoveTo(Vector3.zero);
				yield return new WaitForSeconds(0.7f);
				ChangeAttackType(AttackType.CircleFiring);
			}
			yield return null;
		}
	}

	private void ChangeAttackType(AttackType atkType)
	{
		StopCoroutine(attackType.ToString());
		attackType = atkType;
		StartCoroutine(attackType.ToString());
	}

	IEnumerator CircleFiring()
	{
		attackRate = 0.2f;
		count = 30;
		intervalAngle = 360/count;
		weightAngle = 0;
		isFire = true;
		fireTime = 0;
		while (isFire == true)
		{
			if (fireTime == count)
			{
				yield return new WaitForSeconds(2f);
				if (patternCount != 3)
					ChangeAttackType(AttackType.LazerFiring);
				else if (patternCount == 3)
				{
					patternCount = 0;
					ChangeAttackType(AttackType.SpawnEnemy);
				}
				isFire = false;
			}
			else
			{
				for (int i = 0; i < count; i++)
				{
					GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
					float angle = weightAngle + intervalAngle * i;
					float x = Mathf.Cos(angle * Mathf.PI / 180);
					float y = Mathf.Sin(angle * Mathf.PI / 180);
					clone.GetComponent<BulletMove>().MoveTo(new Vector3(x, y, 0));
					angle += 5;
				}
				weightAngle += 1;
				fireTime++;
				yield return new WaitForSeconds(attackRate);
			}
		}
	}

	IEnumerator LazerFiring()
	{
		attackRate = 0.5f;
		count = 4;
		isFire = true;
		patternCount++;
		while (isFire == true)
		{
			for (int i = 0; i < count; i++)
			{
				float y = Random.Range(-4f, 2f);
				GameObject lr /* 레이저 범위 복사 */ = Instantiate(LazerRange, new Vector3(0, y, 0), Quaternion.identity);
				yield return new WaitForSeconds(2f);
				Destroy(lr);
				GameObject lzr = Instantiate(Lazer, new Vector3(0, y, 0), Quaternion.identity);
				Destroy(lzr, 0.5f);
			}
			isFire = false;
			yield return new WaitForSeconds(attackRate);
		}
		if (isFire == false)
		{
			yield return new WaitForSeconds(1f);
			ChangeAttackType(AttackType.CircleFiring);
		}
	}

	IEnumerator SpawnEnemy()
	{
		fireTime = 0;
		attackRate = 0.5f;
		count = 5;
		isFire = true;
		intervalAngle = 360 / count;
		while (isFire == true)
		{
			for(int c = 0; c < count; c++)
			{
				for (int i = 0; i < count; i++)
				{
					GameObject clone = Instantiate(Enemy, new Vector3(2 - i, transform.position.y, 0), Quaternion.identity);
					Transform p_Trs = GameObject.Find("Player").GetComponent<Transform>();
					Vector3 pos = p_Trs.position;
					clone.GetComponent<BulletMove>().MoveTo((pos - clone.transform.position).normalized);
				}
				fireTime++;
				if (fireTime == count)
				{
					yield return new WaitForSeconds(1f);
					ChangeAttackType(AttackType.CircleFiring);
				}
				yield return new WaitForSeconds(attackRate);
			}
		}
	}
}
