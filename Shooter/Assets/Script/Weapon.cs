using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    /// <summary>
    /// The currently active weapon. May be null.
    /// </summary>
    public WeaponInfo ActiveWeapon;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public bool CanFire
    {
        get
        {
            if (ActiveWeapon == null) return false;
            return ActiveWeapon.GetComponent<Shootable>().CanFire;
        }
    }

    /// <summary>
    /// Attempt to fire the currently equipped weapon.
    /// </summary>
    public void Shoot()
    {
       if(ActiveWeapon != null)
        {
            ActiveWeapon.GetComponent<Shootable>().Shoot(gameObject);
        }
    }

    /// <summary>
    /// Attempts to reload the currently equipped weapon.
    /// </summary>
    public void Reload()
    {
        if (ActiveWeapon != null)
        {
            ActiveWeapon.GetComponent<Shootable>().Reload(gameObject);
        }
    }
}
