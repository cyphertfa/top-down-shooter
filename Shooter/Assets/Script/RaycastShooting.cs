using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour 
{
	private GameObject enemy;
	public float fireDelay = 0; 
	public float damage = 1;
	public LayerMask layermask; 
	float whenToFire = 0 ;
	public Transform firingPoint ; 
	public int health = 10;

    Aim aim;
	// Use this for initialization
	void Awake ()
	{
        aim = GetComponent<Aim>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Fire ();
		if (fireDelay == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Fire ();
			}
		}
		else
		{
			if (Input.GetButton ("Fire1") && Time.time > whenToFire) 
			{
				whenToFire = Time.time + 1 / fireDelay;
				Fire ();
			}
		}
			
	}

	void Fire ()
	{
        Vector2 firePosition = firingPoint.position;
        Vector2 direction = aim.AimVector;

        Debug.Log(direction);

		RaycastHit2D[] hits = Physics2D.RaycastAll (firePosition, direction, 10, layermask );
		Debug.DrawLine (firePosition, firePosition + (direction*10f), Color.black);
		//Debug.Log ("hit");
	    foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                health -= 1;
                Debug.Log("Hit");
            }
        }
		
		if (health <= 0) 
		{
			enemy = GameObject.FindWithTag ("Enemy");
			Destroy (enemy);	
		}

	}


}
