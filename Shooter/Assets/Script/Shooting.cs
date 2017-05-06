using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject FiringPoint;


	public GameObject Bullet;

	public float BulletSpeed = 120;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vector3 velocity = new Vector3();
		if (Input.GetButtonDown ("Fire1"))
		{

			//Instantiating bullet which will create a temporary bullet
			GameObject TemporaryBullet;
			TemporaryBullet = Instantiate(Bullet,FiringPoint.transform.position,FiringPoint.transform.rotation) as GameObject;

			//Assinging the temporary bullet with compoent rigidbody
			Rigidbody TemporaryRigidBody;
			TemporaryRigidBody = TemporaryBullet.GetComponent<Rigidbody>();


			//Adding force to the bullet which willl allow the bullet to travel forward
			TemporaryRigidBody.AddForce(transform.up* BulletSpeed);
			//Getting rid of temporary bullet every 1 second
			Destroy(TemporaryBullet, 1.0f);

		}
	}
}
