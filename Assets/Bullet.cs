using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Hit something");
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.Hit();
		}

		Destroy(gameObject);
	}
}