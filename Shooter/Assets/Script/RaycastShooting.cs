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
	Transform firePoint ; 
	public int health = 10; 
	// Use this for initialization
	void Awake ()
	{
		firePoint = transform.FindChild  ("FiringPoint");
		if (firePoint == null )
		{
			Debug.LogError ("No firing point");
		}
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
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointposition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointposition, mousePosition-firePointposition, 10, layermask );
		Debug.DrawLine (firePointposition,(mousePosition-firePointposition)*10, Color.black  );
		//Debug.Log ("hit");
	

		if (hit.collider != null)
		{
			health -= 1;
			Debug.Log ("dead");

		}
		if (health <= 0) 
		{
			enemy = GameObject.FindWithTag ("Enemy");
			Destroy (enemy);	
		}

	}


}
