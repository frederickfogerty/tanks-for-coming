using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankController : MonoBehaviour
{

	public GameObject BulletPrefab;

	private List<GameObject> _bullets = new List<GameObject>();

	public float ProjectileVelocity = 3;
	public float ProjectileLifetime = 5;

	public Transform BulletSpawn;
	public float TankSpeed;
	public int MaxBullets = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var z = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var forward = Input.GetAxis("Vertical") * Time.deltaTime * TankSpeed;
		transform.Rotate(0, 0, -z);
		transform.Translate(forward * Vector2.up);

		if (Input.GetButtonDown("Jump"))
		{
			Fire();
		}

	}

	private void Fire()
	{
		_bullets = _bullets.Where(y => y != null) //Check for nulls
			.ToList();

		if (_bullets.Count >= MaxBullets)
		{
			// Don't allow more than MaxBullets to be shot
			return;
		}
		var bullet = Instantiate(BulletPrefab,
			BulletSpawn.position, BulletSpawn.rotation);
		_bullets.Add(bullet);
		bullet.GetComponent<Rigidbody2D>().velocity =
			bullet.transform.up * ProjectileVelocity;
		Destroy(bullet, ProjectileLifetime);
//		bullet.
	}
}
