using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Indicates that the current GameObject represents the weapon and has some kind on shooting behaviour attached (from base class <see cref="Shootable"/>).
/// </summary>
[RequireComponent(typeof(Shootable))]
public class WeaponInfo : MonoBehaviour {

    public string WeaponName = "unnamed";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
