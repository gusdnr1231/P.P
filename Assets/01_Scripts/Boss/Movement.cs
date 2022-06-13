using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] Vector3 dir;
	float speed = 5;

	public void Update()
	{
		transform.position += dir * Time.deltaTime * speed;
	}

	public void MoveTo(Vector3 direction)
	{
		dir = direction;
	}
}
