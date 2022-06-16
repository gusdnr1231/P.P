using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { BossStart = 0, Phase1, Phase2, }

public class Boss : MonoBehaviour
{
	private BossManager bm;
	private Movement movement;
	private BossState state = BossState.BossStart;
	private float bossPoint = 5f;
	bool lazer;

	private void Awake()
	{
		bm = GetComponent<BossManager>();
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
				ChangeState(BossState.Phase1);
			}
			yield return null;
		}
	}

	public void ChangeState(BossState newState)
	{
		StopCoroutine(state.ToString());
		state = newState;
		StartCoroutine(state.ToString());
	}


	private IEnumerator Phase1()
	{
		bm.StartFiring(AttackType.CircleFiring);
		yield return new WaitForSeconds(3f);
		bm.StopFiring(AttackType.CircleFiring);
		ChangeState(BossState.Phase2);
	}

	private IEnumerator Phase2()
	{
		bm.StartFiring(AttackType.LazerFiring);
		yield return new WaitForSeconds(3f);
		bm.StopFiring(AttackType.CircleFiring);
		ChangeState(BossState.Phase1);

	}
}
