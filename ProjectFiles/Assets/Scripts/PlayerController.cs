using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public float speed;
	[SerializeField] private float rotationSpeed;
	private float maxSpeed = 30;

	[SerializeField] private ParticleSystem pickUpVfx;
    void Update()
    {
		if (GameHandler.instance.gameStarted)
		{
			if (speed < maxSpeed)
				speed += 0.1f * Time.deltaTime;
		}
			

		transform.Translate(0, 0, speed * Time.deltaTime);

		if(Input.GetMouseButton(0))
		transform.RotateAround(transform.position, Vector3.forward , Input.GetAxis("Mouse X") * rotationSpeed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obj"))
		{
			speed = 0;
			GameHandler.instance.GameOverPanel();
		}

		if (other.gameObject.CompareTag("Gem"))
		{
			GameHandler.instance.gemCounter += 1;
			Instantiate(pickUpVfx, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y+1, other.gameObject.transform.position.z), Quaternion.identity);
			Destroy(other.gameObject);
		}

	}
}
