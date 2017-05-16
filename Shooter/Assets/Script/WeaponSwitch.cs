using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public const int TOTAL_WEAPON_SLOTS = 4;

    /// <summary>
    /// The currently equipped weapon.
    /// </summary>
    private WeaponInfo currentlyEquipped;

    /// <summary>
    /// The index of the currently held weapon in heldWeapons.
    /// </summary>
    private int currentlyEquppedIndex;

    /// <summary>
    /// List of currently held weapons.
    /// This should be populated during initialization by searching though this objects children for all WeaponInfo behaviours.
    /// </summary>
    private List<WeaponInfo> heldWeapons = new List<WeaponInfo>();


	//private Shooting enableShooting;
	//private RaycastShooting enableRaycast; 

	// Use this for initialization
	void Start () 
	{
		//enableShooting = GetComponent<Shooting> ();
		//enableRaycast = GetComponent<RaycastShooting> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
            //enableShooting.enabled = true; 
            //enableRaycast.enabled = false; 
            SwitchWeapon(0);

        } 
		if (Input.GetKeyDown (KeyCode.Alpha2))
		{
            //enableShooting.enabled = false; 
            //enableRaycast.enabled = true; 
            SwitchWeapon(1);
        }
		
	}

    /// <summary>
    /// Switches to weapon in the current slot index. 
    /// 
    /// The field 'Weilder' on the equipped weapons WeaponInfo should be updated with this component when the weapon is equipped.
    /// The field 'Weilder' on the unequipped weapons WeaponInfo should be set to null.
    /// </summary>
    /// <param name="slot">The index of the slot to switch to.</param>
    public void SwitchWeapon(int slot)
    {
		for (var i = 0; i < transform.childCount; i++)
		{
			if (i == slot) {
				transform.GetChild (i).gameObject.SetActiveRecursively (true);
			} else {
				transform.GetChild (i).gameObject.SetActiveRecursively (false);
			}
		}
    }
}
