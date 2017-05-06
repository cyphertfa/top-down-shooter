using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Aim))]
public class Shooting : MonoBehaviour {

    public Transform FiringPoint;
	public GameObject Bullet;
    public bool Inheritance = true;

    private Rigidbody2D rigidBodySelf;

    /// <summary>
    /// Speed of bullet in unity units per second.
    /// </summary>
	public float BulletSpeed = 120;

    /// <summary>
    /// Minimum delay between firing in seconds.
    /// </summary>
    public float ShotDelay = 0.05f;

    private float ShotCooldown = 0f;

    public bool CanFire {  get
        {
            return ShotCooldown <= 0;
        }
    }

	// Use this for initialization
	void Start () 
	{
        rigidBodySelf = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        ShotCooldown -= Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && ShotCooldown <= 0)
		{

			//Instantiating bullet which will create a temporary bullet
			GameObject TemporaryBullet;
			TemporaryBullet = Instantiate(Bullet,FiringPoint.position,FiringPoint.rotation) as GameObject;

			//Assinging the temporary bullet with compoent rigidbody
			Rigidbody2D TemporaryRigidBody;
			TemporaryRigidBody = TemporaryBullet.GetComponent<Rigidbody2D>();

            //Add force inherited from the movement of the parent
            if(Inheritance)
            {
                TemporaryRigidBody.velocity = rigidBodySelf.velocity;
            }

            //Adding force to the bullet which willl allow the bullet to travel forward
            TemporaryRigidBody.AddForce(transform.right* BulletSpeed);

            //Getting rid of temporary bullet every 1 second
            Destroy(TemporaryBullet, 1.0f);


            ShotCooldown = ShotDelay;
		}
	}
}
