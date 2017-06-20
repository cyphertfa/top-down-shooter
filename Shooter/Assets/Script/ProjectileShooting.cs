using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : Shootable {
    /// <summary>
    /// The location the projectile should spawn.
    /// </summary>
    public Transform FiringPoint;
    /// <summary>
    /// A prefab of the type of projectile to spawn.
    /// </summary>
	public GameObject Projectile;
    /// <summary>
    /// Should tis projectile inherit velocity from its parent?
    /// </summary>
    public bool Inheritance = true;
    /// <summary>
    /// Speed of bullet in unity units per second.
    /// </summary>
	public float BulletSpeed = 120;
    /// <summary>
    /// Minimum delay between firing in seconds.
    /// </summary>
    public float ShotDelay = 0.05f;

    private float shotCooldown = 0f;

    public override bool CanFire {  get
        {
            return shotCooldown <= 0;
        }
    }

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        shotCooldown -= Time.deltaTime;
	}

    public override bool Shoot(GameObject parent)
    {
        //We need to store the value at this point in time because its value could change by the end of this method.
        bool canFire = CanFire;
        if(canFire)
        {
            //Instantiating bullet which will create a temporary bullet
            GameObject projectile;
            projectile = Instantiate(Projectile, FiringPoint.position, FiringPoint.rotation) as GameObject;

            //Assinging the temporary bullet with compoent rigidbody
            Rigidbody2D projectileBody;
            projectileBody = projectile.GetComponent<Rigidbody2D>();

            //Add force inherited from the movement of the parent
            if (Inheritance)
            {
                projectileBody.velocity = parent.GetComponent<Rigidbody2D>().velocity;
            }

            //Adding force to the bullet which willl allow the bullet to travel forward
            projectileBody.AddForce(FiringPoint.transform.right * BulletSpeed);

            //Getting rid of temporary bullet every 1 second -TODO: projectile should be responsible for lifetime!
            Destroy(projectile, 1.0f);


            shotCooldown = ShotDelay;
        }

        return canFire;
    }

    public override bool Reload(GameObject parent)
    {
        return false; //Not yet implemented.
    }
}
