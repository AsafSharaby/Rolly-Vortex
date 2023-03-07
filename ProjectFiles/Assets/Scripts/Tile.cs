using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public TileType tileType;

	[SerializeField] private float speed;
	[SerializeField] private GameObject gam;
	[SerializeField] private Transform point;

	private int number = 0;

	private void Start()
	{
		number = Random.Range(1,10);

		if (tileType == TileType.Normal)
			if (number == 2)
				Instantiate(gam, point.transform.position, Quaternion.Euler(-90, 0, 0));

	}
	void Update()
	{
		if(tileType == TileType.Spin)
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}

public enum TileType
{
	Spin,
	Normal
}
