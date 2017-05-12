using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : Shootable 
{
    /// <summary>
    /// The location the projectile should spawn.
    /// </summary>
    public Transform FiringPoint;
    //TODO Hitscan Visual type
    /// <summary>
    /// Minimum delay between firing in seconds.
    /// </summary>
    public float ShotDelay = 0.05f;
    /// <summary>
    /// How much damage the hitscan should do
    /// TODO: Move this into a hitscan prefab (like projectiles)
    /// </summary>
    public float Damage = 1;
	/// <summary>
    /// Layers which should be used to check for contacts.
    /// </summary>
	public LayerMask LayerMask;

    private float shotCooldown;
    private Aim aim;

    public override bool CanFire
    {
        get
        {
            return shotCooldown <= 0;
        }
    }

	// Use this for initialization
	void Awake ()
	{
        aim = GetComponent<Aim>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        shotCooldown -= Time.deltaTime;
    }

    public override bool Shoot(GameObject parent)
    {
        bool canFire = CanFire;
        if(canFire)
        {
            Vector2 firePosition = FiringPoint.position;
            Vector2 direction = aim.AimVector;

            RaycastHit2D[] hits = Physics2D.RaycastAll(firePosition, direction, 10, LayerMask);
            Debug.DrawLine(firePosition, firePosition + (direction * 10f), Color.black);
            //Debug.Log ("hit");
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Health>().Damage(1);
                }
            }
            shotCooldown = ShotDelay;
        }
        return canFire;
        
    }

    public override bool Reload(GameObject parent)
    {
        return false; //Not yet implemented.
    }
}
