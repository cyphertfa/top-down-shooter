using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public const int TOTAL_WEAPON_SLOTS = 4;

    /// <summary>
    /// The currently active weapon. May be null.
    /// </summary>
    public WeaponInfo ActiveWeapon;

    /// <summary>
    /// The index of the currently held weapon in heldWeapons.
    /// </summary>
    private int activeIndex;

    /// <summary>
    /// List of currently held weapons.
    /// This should be populated during initialization by searching though this objects children for all WeaponInfo behaviours.
    /// </summary>
    private List<WeaponInfo> heldWeapons = new List<WeaponInfo>();

    /// <summary>
    /// Mapping for each weapon select key.
    /// </summary>
    private KeyCode[] mapping = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };

    /// <summary>
    /// Indicates if this weapon can currently fire (i.e. not reloading, has ammo)
    /// </summary>
    public bool CanFire
    {
        get
        {
            if (ActiveWeapon == null) return false;
            return ActiveWeapon.GetComponent<Shootable>().CanFire;
        }
    }

    // Use this for initialization
    void Start()
    {
        RefreshWeaponList();
    }

    // Update is called once per frame
    void Update()
    {
        int index = 0;
        //Iterate through all the key mappings, switching to the appropriate index when press is detected.
        foreach (KeyCode key in mapping)
        {
            if (Input.GetKeyDown(key))
            {
                SwitchWeapon(index);
            }

            index++;
        }

    }

    /// <summary>
    /// This method should be called whenever the weapon inventory changes.
    /// </summary>
    public void RefreshWeaponList()
    {
        //Clear the list as we will repopulate it from scratch.
        heldWeapons.Clear();
        for (var i = 0; i < transform.childCount; i++)
        {
            WeaponInfo info = transform.GetChild(i).GetComponent<WeaponInfo>();
            //It may be possible we select non-weapon children, so we must check the game object has a weaponInfo behaviour to ensure it is a weapon.
            if (info != null)
            {
                heldWeapons.Add(info);
            }
        }
    }

    /// <summary>
    /// Switches to weapon in the given slot index. 
    /// </summary>
    /// <param name="slot">The index of the slot to switch to.</param>
    public void SwitchWeapon(int slot)
    {
        if (heldWeapons.Count > slot)
        {
            WeaponInfo weapon = heldWeapons[slot];
            //We should not switch to the weapon if it is already selected.
            if(weapon != ActiveWeapon)
            {
                Debug.Log(string.Format("Switched to weapon index {0} ({1}).", slot, weapon.WeaponName));
                ActiveWeapon = weapon;
                activeIndex = slot;
            }
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
