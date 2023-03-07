using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform target;

	[SerializeField] private Vector3 offSet;
	void Start()
	{
		target = FindObjectOfType<PlayerController>().transform;
	}

	void LateUpdate()
	{
		Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offSet.z + target.position.z);
		transform.position = newPosition;
	}
}
