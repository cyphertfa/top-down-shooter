using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public abstract bool CanFire
    {
        get;
    }

    /// <summary>
    /// Fires the current weapon.
    /// </summary>
    /// <param name="parent">The parent which is firing the weapon</param>
    /// <returns>If this weapon can currently fire.</returns>
    public abstract bool Shoot(GameObject parent);

    /// <summary>
    /// Reloads the current weapon.
    /// </summary>
    /// <param name="parent">The parent that is attempting to reload the weapon</param>
    /// <returns>If the weapon can be reloaded (i.e not already full and there is ammo available)</returns>
    public abstract bool Reload(GameObject parent);
        
}
