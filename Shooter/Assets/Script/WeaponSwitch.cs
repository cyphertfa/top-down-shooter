using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
	private Shooting enableShooting;
	private RaycastShooting enableRaycast; 
	// Use this for initialization
	void Start () 
	{
		enableShooting = GetComponent<Shooting> ();
		enableRaycast = GetComponent<RaycastShooting> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			enableShooting.enabled = true; 
			enableRaycast.enabled = false; 
		} 
		if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			enableShooting.enabled = false; 
			enableRaycast.enabled = true; 
		}
		
	}
}
