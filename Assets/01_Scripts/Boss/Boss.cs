using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { BossStart = 0, Phase01, }

public class Boss : MonoBehaviour
{
    private BossManager bm;
	private Movement movement;
	private BossState state = BossState.BossStart;
	private float bossPoint = 5f;


	private void Awake()
	{
		bm = GetComponent<BossManager>();
		movement = GetComponent<Movement>();
	}

	private void Update()
	{
		StartCoroutine("BossStart");
	}


	public void ChangeState(BossState newsState)
	{
		StopCoroutine(state.ToString());
		state = newsState;
		StartCoroutine(state.ToString());
	}

	private IEnumerator BossStart()
	{
		movement.MoveTo(Vector3.down);
		while (true)
		{
			if ( transform.position.y <= bossPoint)
			{
				movement.MoveTo(Vector3.zero);
				ChangeState(BossState.Phase01);
			}
			yield return null;
		}
	}

	private IEnumerator Phase01()
	{
		bm.StartFiring(AttackType.CircleFiring);
		while (true)
		{
			yield return null;
		}
	}





}
